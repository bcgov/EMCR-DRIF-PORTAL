FROM trion/ng-cli-karma AS node-builder
WORKDIR /src
COPY ./package*.json ./

RUN npm install --ignore-scripts
RUN npm i @esbuild/linux-x64 --save
COPY . .

FROM node-builder as ng-builder
RUN npm run build --configuration=production

FROM caddy:2-builder AS builder
RUN xcaddy build --with github.com/caddyserver/replace-response

FROM caddy:2 as final
ARG VERSION
ENV VERSION=$VERSION
ENV API_URL=
RUN chmod +rw /config/caddy
COPY --from=builder /usr/bin/caddy /usr/bin/caddy
COPY Caddyfile /etc/caddy/Caddyfile
COPY --from=ng-builder /src/dist/drr/browser /site
COPY robots.txt /site/robots.txt
EXPOSE 2015
