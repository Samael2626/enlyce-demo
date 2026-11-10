# Item 4 - Pruebas de interfaz grafica (GUI): estandares de calidad

> BORRADOR. Completar con capturas reales de la demo en marcha.

## 1. Interfaz evaluada
CRM de Enlyce Demo (`frontend/`, React + Vite + Tailwind) y sitio publico (`website/sitio/`, Next.js).

## 2. Estandares y paginas de referencia usadas
| Estandar / recurso | Pagina | Como se aplica en la demo |
|---|---|---|
| Material Design 3 | https://m3.material.io/ | Jerarquia tipografica, estados de foco, botones primarios y secundarios |
| WCAG 2.2 AA | https://www.w3.org/TR/WCAG22/ | Contraste, etiquetas `<label>` en formularios, `role="alert"` en errores de login |
| Bootswatch / Materialize | https://bootswatch.com/ , https://materializecss.com/ | Comparacion de paletas y componentes |

(Anotar cual se uso realmente y con que criterio.)

## 3. Casos de prueba de GUI
| # | Pantalla | Verificacion | Resultado esperado | Automatizada |
|---|---|---|---|---|
| 1 | Login CRM | Credenciales validas | Redirige a `/dashboard` | `CrmLoginTests.Login_with_valid_credentials_opens_dashboard` |
| 2 | Login CRM | Clave incorrecta | Mensaje en `role="alert"`, sigue en `/login` | `CrmLoginTests.Login_with_wrong_password_shows_error_and_stays_on_login` |
| 3 | Sitio publico | Carga de portada | Titulo con "Enlyce" | `PublicSiteTests.Home_page_loads_with_title` |
| 4 | Listado publico | Inmuebles del seed | Al menos una tarjeta | `PublicSiteTests.Property_listing_shows_seeded_demo_properties` |

## 4. Como ejecutar
Ver `README.md` (seccion Pruebas). Adjuntar captura de la salida de `dotnet test tests/Enlyce.E2E.Selenium`.

## 5. Evidencias
- [ ] Captura del login
- [ ] Captura del error de credenciales
- [ ] Captura del resultado de Selenium
- [ ] Informe de accesibilidad (axe/Lighthouse) de la portada
