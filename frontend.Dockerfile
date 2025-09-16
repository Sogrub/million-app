FROM node:20-alpine AS build
WORKDIR /app
COPY million-front/package*.json ./
RUN npm install
COPY million-front/ .

ARG NEXT_PUBLIC_API_URL
ENV NEXT_PUBLIC_API_URL=$NEXT_PUBLIC_API_URL

RUN npm run build

FROM node:20-alpine AS runtime
WORKDIR /app
COPY --from=build /app ./
EXPOSE 3000
CMD ["npm", "start"]
