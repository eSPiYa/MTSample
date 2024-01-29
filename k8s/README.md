# Simple deployment on Kubernetes
### Create namespace **mtsample**
run on command prompt `kubectl create namespace mtsample`

### Then run the deployments and services
`kubectl -n mtsample apply -f configmap.yml,rabbitmq.yml,redis-cache.yml,background-worker.yml,web-api.yml`
