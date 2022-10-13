import Vue from 'vue'
import VueRouter from 'vue-router'
import HomeView from '../views/HomeView.vue'
import LoginView from '../views/LoginView.vue'
import ItemsTestView from '../views/ItemsTestView.vue'
import RegistrationView from '../views/RegistrationView.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/login',
    name: 'login',
    component: LoginView
  },
  {
    path: '/register',
    name: 'register',
    component: RegistrationView
  },
  {
    path: '/items',
    name: 'items',
    component: ItemsTestView
  }
]

const router = new VueRouter({
  routes
})

export default router
