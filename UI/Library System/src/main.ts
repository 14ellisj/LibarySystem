import './styles/variables.css'
import './styles/styles.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'
import axios from 'axios'
import toastr from './plugins/toastr'

const app = createApp(App)

app.config.globalProperties.$toastr = toastr

app.use(createPinia())
app.use(router)

app.mount('#app')
