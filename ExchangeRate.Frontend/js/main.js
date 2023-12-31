const serverUrl = 'http://217.71.129.139:5513';

let fromBlock;
let toBlock;
let centralBankLabel;
let centralBankList;
let fromCurrencyLabel;
let fromCurrencyList;
let fromAmountInput;
let toCurrencyLabel;
let toCurrencyList;
let toAmountInput;

document.addEventListener("DOMContentLoaded", function () {
    fromBlock = document.getElementById('from');
    toBlock = document.getElementById('to');
    centralBankLabel = fromBlock.querySelector('.converter__select-central-bank .converter__select-label');
    centralBankList = fromBlock.querySelector('.converter__select-central-bank .converter__select-list');
    fromCurrencyLabel = fromBlock.querySelector('.converter__select-currency .converter__select-label');
    fromCurrencyList = fromBlock.querySelector('.converter__select-currency .converter__select-list');
    fromAmountInput = fromBlock.querySelector('.converter__input');
    toCurrencyLabel = toBlock.querySelector('.converter__select-currency .converter__select-label');
    toCurrencyList = toBlock.querySelector('.converter__select-currency .converter__select-list');
    toAmountInput = toBlock.querySelector('.converter__input');

    dropdown();
    amountInputs();

    loadCentralBankList();
});

function swap() {
    let temp = fromCurrencyLabel.innerText;
    fromCurrencyLabel.innerText = toCurrencyLabel.innerText;
    toCurrencyLabel.innerText = temp;

    temp = fromAmountInput.value;
    fromAmountInput.value = toAmountInput.value;
    toAmountInput.value = temp;
}

function dropdown() {
    document.querySelectorAll('.converter__select-arrow').forEach(function (selectButton) {
        selectButton.addEventListener('click', function (e) {
            const selectWrapper = selectButton.parentElement.parentElement;
            const label = selectWrapper.querySelector('.converter__select-label');
            const openList = selectWrapper.querySelector('.converter__select-list');
            const openItems = openList.querySelectorAll('.converter__select-item');

            if (openList.classList.contains('open')) {
                openList.classList.remove('open');
                return;
            }

            document.addEventListener('click', function (e) {
                if (e.target !== selectButton && e.target !== openList) {
                    openList.classList.remove('open');
                }
            });

            openList.classList.toggle('open');

            openItems.forEach(function (item) {
                item.addEventListener('click', function () {
                    label.innerText = this.innerText;
                    if (label === centralBankLabel) {
                        centralBankLabelUpdate();
                    } else {
                        convert();
                    }

                    openList.classList.remove('open');
                })
            })
        })

    });
}

function amountInputs() {
    let inputs = document.querySelectorAll(".converter__input");
    inputs.forEach(item => {
        item.addEventListener("input", function (event) {
            const value = event.target.value;
            const isValid = /^((0|[1-9][0-9]{0,9})(\.[0-9]{0,4})?)$/g.test(value);
            if (!isValid) {
                event.target.value = value.slice(0, -1);
            }
        })
    })

    fromAmountInput.addEventListener("input", function (event) {
        convert();
    });
}

// <li class="converter__select-item">RUB</li>

function loadCentralBankList() {
    let xhr = new XMLHttpRequest();

    xhr.open("GET", `${serverUrl}/api/AvailableCountries/GetAvailableCountries`, true);

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200) {
            let data = JSON.parse(xhr.responseText);

            // remove all child elements
            centralBankList.childNodes.forEach(item => {
                item.remove();
            });

            data.countries.sort((a, b) => a.name > b.name ? 1 : -1).forEach(country => {
                let element = document.createElement('ul');
                element.classList.add('converter__select-item');
                element.innerText = country.name;
                centralBankList.append(element);
            })

            centralBankLabel.innerText = data.countries[0].name;

            centralBankLabelUpdate();

            document.querySelector('main').style.display = 'block';
            document.querySelector('.loader').style.display = 'none';
        }
    };

    xhr.send();
}

function centralBankLabelUpdate() {
    let xhr = new XMLHttpRequest();

    let country = centralBankLabel.innerText;
    xhr.open("GET", `${serverUrl}/api/AvailableCurrencies/GetAvailableCurrencies?country=${country}`, true);

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200) {
            let data = JSON.parse(xhr.responseText);
            data.currenciesNames.sort();
            const lists = document.querySelectorAll('.converter__select-currency .converter__select-list');
            lists.forEach(item => {
                // remove all child elements
                item.childNodes.forEach(item => {
                    item.remove();
                });
                data.currenciesNames.sort((a, b) => a.charCode > b.charCode ? 1 : -1).forEach(currency => {
                    let element = document.createElement('ul');
                    element.classList.add('converter__select-item');
                    element.innerText = currency.charCode;
                    item.append(element);
                })
            })

            fromCurrencyLabel.innerText = data.currenciesNames[0].charCode;
            toCurrencyLabel.innerText = data.currenciesNames[0].charCode;
            convert();
        }
    };

    xhr.send();
}

function convert() {
    let xhr = new XMLHttpRequest();

    let country = centralBankLabel.innerText;
    let from = fromCurrencyLabel.innerText;
    let to = toCurrencyLabel.innerText;
    let amount = fromAmountInput.value;

    if (country === '') {
        toAmountInput.value = '';
        return;
    }

    if (from === '') {
        toAmountInput.value = '';
        return;
    }

    if (to === '') {
        toAmountInput.value = '';
        return;
    }

    if (amount === '' || amount === '0') {
        toAmountInput.value = '';
        return;
    }

    if (from === to) {
        toAmountInput.value = amount;
        return;
    }

    xhr.open("GET", `${serverUrl}/api/Convert/Convert?Country=${country}&Amount=${amount}&From=${from}&To=${to}`, true);

    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200) {
            let data = JSON.parse(xhr.responseText);
            toAmountInput.value = data.amount;
        }
    };

    xhr.send();
}