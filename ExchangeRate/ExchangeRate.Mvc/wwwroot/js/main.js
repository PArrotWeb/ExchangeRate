document.addEventListener("DOMContentLoaded", function() {
    document.querySelectorAll('.converter__select-arrow').forEach(function (selectButton) {
        selectButton.addEventListener('click', function(e){
            const selectWrapper = selectButton.parentElement.parentElement;
            const label = selectWrapper.querySelector('.converter__select-label');
            const openList = selectWrapper.querySelector('.converter__select-list');
            const openItems = openList.querySelectorAll('.converter__select-item');

            if (openList.classList.contains('open')) {
                openList.classList.remove('open');
                return;
            }

            document.addEventListener('click', function(e){
                if (e.target !== selectButton && e.target !== openList) {
                    openList.classList.remove('open');
                }
            });

            openList.classList.toggle('open');

            openItems.forEach(function(item) {
                item.addEventListener('click',function(){
                    label.innerText = this.innerText;
                    openList.classList.remove('open');
                })
            })
        })

    })
});
