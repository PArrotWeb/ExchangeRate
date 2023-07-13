FROM nginx
WORKDIR /app
EXPOSE 80
COPY ./ /data/www/
COPY ensite.conf /etc/nginx/conf.d/ensite.conf
COPY nginx.conf /etc/nginx/nginx.conf