# Enlyce Demo

CRM inmobiliario de demostracion (Ingenieria de Software II, ET0191). Version reducida del proyecto Enlyce, **sin datos reales**: todo lo que muestra el seed es ficticio.

Stack: ASP.NET Core 10 + EF Core + PostgreSQL, CRM en React/Vite, sitio publico en Next.js. Arquitectura limpia (Domain, Application, Infrastructure, Api).

## Requisitos
- Docker Desktop (con el daemon encendido)
- .NET SDK 10 (solo para correr pruebas fuera de Docker)
- Node 24 (solo para desarrollo del front)
- Google Chrome (pruebas Selenium) y Apache JMeter 5.6+ (pruebas de carga)

## Levantar todo
```bash
docker compose up -d --build
```
| Servicio | URL |
|---|---|
| CRM (login) | http://localhost:5019/login |
| API (health) | http://localhost:5019/health |
| Sitio publico | http://localhost:3000 |
| PostgreSQL | localhost:5436 (usuario `postgres`) |

Credenciales de demo del CRM: `admin@enlyce.test` / `DemoEnlyce2026!!`
(valores ficticios definidos en `docker-compose.yml`; no reutilizar en ningun entorno real).

Para apagar: `docker compose down -v`.

## Pruebas
```bash
dotnet test Enlyce.slnx                      # xUnit: dominio, aplicacion e integracion
dotnet test tests/Enlyce.E2E.Selenium        # Selenium; requiere la demo arriba
jmeter -n -t tests/carga/api-carga.jmx -l tests/carga/resultados.jtl -e -o tests/carga/reporte
```
Variables de Selenium: `DEMO_CRM_URL`, `DEMO_WEB_URL`, `DEMO_ADMIN_EMAIL`, `DEMO_ADMIN_PASSWORD`, `DEMO_HEADED=1` para ver el navegador.
Parametros de JMeter: `-Jthreads=20 -Jloops=20 -Jramp=10 -Jhost=localhost -Jport=5019`.

CI: `Jenkinsfile` (compilar, pruebas, build del front, demo en Docker, Selenium, JMeter).

## Estructura
```
src/        Domain, Application, Infrastructure, Api
tests/      Domain.Tests, Application.Tests, IntegrationTests, E2E.Selenium, carga (JMeter)
frontend/   CRM (React + Vite)
website/    sitio publico (Next.js) y assets de demo
docs/       arquitectura y borradores de entregables
```

## Que NO incluye
Datos de clientes, credenciales, integraciones con terceros reales, logos ni textos del cliente original. Los logos son marcadores de posicion.
