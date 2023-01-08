import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

import '@fortawesome/fontawesome-free/js/all'
import './assets/main.css'

const app = createApp(App)

app.use(router)

app.mount('#app')
