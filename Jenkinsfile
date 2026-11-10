// Pipeline de integracion continua de la demo. Agente con .NET SDK 10, Node 24 y Docker.
pipeline {
  agent any
  options { timestamps() }
  stages {
    stage('Compilar') {
      steps { sh 'dotnet build Enlyce.slnx --configuration Release' }
    }
    stage('Pruebas unitarias e integracion') {
      steps { sh 'dotnet test Enlyce.slnx --configuration Release --no-build --logger "trx;LogFileName=resultados.trx"' }
      post { always { junit allowEmptyResults: true, testResults: '**/TestResults/*.trx' } }
    }
    stage('Front CRM') {
      steps { dir('frontend') { sh 'npm ci && npm run build' } }
    }
    stage('Levantar demo') {
      steps { sh 'docker compose up -d --build --wait' }
    }
    stage('Selenium (E2E)') {
      steps { sh 'dotnet test tests/Enlyce.E2E.Selenium' }
    }
    stage('JMeter (carga)') {
      steps {
        sh 'jmeter -n -t tests/carga/api-carga.jmx -l tests/carga/resultados.jtl -e -o tests/carga/reporte -Jthreads=20 -Jloops=20'
        archiveArtifacts artifacts: 'tests/carga/reporte/**', allowEmptyArchive: true
      }
    }
  }
  post { always { sh 'docker compose down -v || true' } }
}
