import Vue from 'vue'
import Buefy from 'buefy'
import 'buefy/dist/buefy.css'
import { FontAwesomeIcon, FontAwesomeLayers, FontAwesomeLayersText } from '@fortawesome/vue-fontawesome'
Vue.component('font-awesome-icon', FontAwesomeIcon)
Vue.component('font-awesome-layers', FontAwesomeLayers)
Vue.component('font-awesome-layers-text', FontAwesomeLayersText)
import { library } from '@fortawesome/fontawesome-svg-core'
import { faSpinner, faAlignLeft, fas} from '@fortawesome/free-solid-svg-icons'
 library.add(faSpinner, faAlignLeft,fas)
 
Vue.use(Buefy)
import App from './App.vue'
import './registerServiceWorker'
import router from './router'

Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
