# Examen final - Laboratorio de pruebas (Selenium, JMeter, Jenkins)

> BORRADOR. Pedido por el profesor: 1) anexar el codigo, 2) paso a paso desde instalacion y uso, 3) video corto del laboratorio.

## 1. Codigo anexo
- `tests/Enlyce.E2E.Selenium/` (Selenium WebDriver + xUnit, C#)
- `tests/carga/api-carga.jmx` (JMeter)
- `Jenkinsfile` (Jenkins)
- Equivalente a JUnit en este proyecto: xUnit (`tests/Enlyce.*.Tests`).

## 2. Paso a paso
### 2.1 Entorno
1. Instalar Docker Desktop, .NET SDK 10, Google Chrome.
2. Instalar JMeter 5.6+ (https://jmeter.apache.org/download_jmeter.cgi) y agregar `bin` al PATH. Requiere Java 17+.
3. `docker compose up -d --build`.

### 2.2 xUnit (equivalente a JUnit)
`dotnet test Enlyce.slnx` -> 593 pruebas en la ultima corrida local (58 aplicacion, 256 dominio, 279 integracion, 1 omitida por requerir Postgres externo).

### 2.3 Selenium
`dotnet test tests/Enlyce.E2E.Selenium` (con `DEMO_HEADED=1` para ver el navegador).
Estado: compila; **pendiente ejecutar contra la demo levantada** antes de entregar.

### 2.4 JMeter
`jmeter -n -t tests/carga/api-carga.jmx -l tests/carga/resultados.jtl -e -o tests/carga/reporte`
Para abrirlo con interfaz: `jmeter -t tests/carga/api-carga.jmx`.
Estado: XML valido; **pendiente ejecutar** y registrar tiempos de respuesta y tasa de error.

### 2.5 Jenkins
1. `docker run -d -p 8081:8080 -v jenkins_home:/var/jenkins_home jenkins/jenkins:lts` (o instalador de Windows).
2. Crear un Pipeline apuntando al repo; usa el `Jenkinsfile` de la raiz.
3. El agente necesita .NET 10, Node, Docker y JMeter.
Estado: Jenkinsfile escrito, **no ejecutado**.

## 3. Video corto
Guion sugerido (3-5 min): levantar compose, mostrar login, correr xUnit, correr Selenium con navegador visible, correr JMeter y abrir el reporte, mostrar pipeline en Jenkins.

## 4. Resultados
(Completar con los numeros reales de cada corrida.)
