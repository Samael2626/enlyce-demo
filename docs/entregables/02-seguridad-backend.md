# Item 5 - Pruebas de seguridad (backend) y montaje paso a paso

> BORRADOR. Los hallazgos de la seccion 3 deben confirmarse ejecutando las pruebas; lo no ejecutado esta marcado.

## 1. Montaje
1. `docker compose up -d --build` (ver `README.md`).
2. Verificar `http://localhost:5019/health`.
3. Herramienta de analisis: OWASP ZAP (escaneo pasivo y activo contra `http://localhost:5019`).

## 2. Controles de seguridad presentes en el codigo
| Control | Donde |
|---|---|
| Hash de contrasenas con bcrypt | `Auth` / `BCrypt.Net` en el login y bootstrap |
| JWT con clave minima de 32 bytes, validada al arrancar | `Program.cs` |
| Limite de intentos de login por correo | `AuthModule` (`attempts.CanAttempt`) |
| Cookie HttpOnly de sesion | `_enlyce_auth` |
| Cabeceras de seguridad | `Middleware/SecurityHeadersMiddleware.cs` |
| CSP y cabeceras en el sitio publico | `website/sitio/next.config.ts` |
| CORS por lista de origenes | `Program.cs` |
| Baja logica con auditoria; consentimiento de datos (Ley 1581) | Dominio |

## 3. Vulnerabilidad a documentar (elegir una tras el informe ZAP)
Estructura pedida:
1. Que es la vulnerabilidad.
2. Como se realiza el ataque (pasos reproducibles contra la demo local).
3. Contramedida y como se verifica.

Candidatas razonables: cabeceras ausentes o mal configuradas, CORS permisivo, fuerza bruta de login (mitigada por throttling), exposicion de informacion en errores.

## 4. Procedimiento de ataque y contramedida (plantilla)
- Preparacion: ...
- Ataque: ... (capturas)
- Resultado sin contramedida: ...
- Contramedida aplicada: ...
- Resultado con contramedida: ...

## 5. Evidencias
- [ ] Informe ZAP exportado
- [ ] Capturas del ataque y de la contramedida
