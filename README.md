# 🏡 Million Project

Proyecto de prueba técnica con **.NET 8 (Backend)**, **MongoDB** y **Next.js 15 (Frontend)**, todo orquestado con **Docker Compose**.

---

## 🚀 Requisitos

- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

---

## 📂 Estructura del proyecto

.
├── backend.Dockerfile
├── frontend.Dockerfile
├── docker-compose.yml
├── million-backend/ # Código del backend (ASP.NET Core)
├── million-front/ # Código del frontend (Next.js)
└── README.md


---

## ▶️ Levantar el proyecto

Clona el repositorio:

```bash
git clone https://github.com/Sogrub/million-app.git
cd million


docker compose up --build
```

Esto va a:

Crear la base de datos MongoDB en http://localhost:27027

Levantar el backend en http://localhost:5000

Levantar el frontend en http://localhost:3000