import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import CaseView from '../views/cases.vue'
import ComputerView from '../views/computers.vue'
import CoolerView from '../views/coolers.vue'
import GpuView from '../views/gpu.vue'
import HeadsetView from '../views/headsets.vue'
import KeyboardView from '../views/keyboards.vue'
import MonitorView from '../views/monitors.vue'
import MotherboardView from '../views/motherboards.vue'
import MouseView from '../views/mouses.vue'
import PsuView from '../views/psu.vue'
import CpuView from '../views/cpu.vue'
import RamView from '../views/ram.vue'
import ContactView from '../views/contact.vue'
import LoginView from '../views/login.vue'
import RegisterView from '../views/register.vue'
import CartView from '../views/cart.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/cases',
      name: 'cases',
      component: CaseView
    },
    {
      path: '/computers',
      name: 'computers',
      component: ComputerView
    },
    {
      path: '/coolers',
      name: 'coolers',
      component: CoolerView
    },
    {
      path: '/gpu',
      name: 'gpu',
      component: GpuView
    },
    {
      path: '/headsets',
      name: 'headsets',
      component: HeadsetView
    },
    {
      path: '/keyboards',
      name: 'keyboards',
      component: KeyboardView
    },
    {
      path: '/monitors',
      name: 'monitors',
      component: MonitorView
    },
    {
      path: '/motherboards',
      name: 'motherboards',
      component: MotherboardView
    },
    {
      path: '/mouses',
      name: 'mouses',
      component: MouseView
    },
    {
      path: '/psu',
      name: 'psu',
      component: PsuView
    },
    {
      path: '/cpu',
      name: 'cpu',
      component: CpuView
    },
    {
      path: '/ram',
      name: 'ram',
      component: RamView
    },
    {
      path: '/contact',
      name: 'contact',
      component: ContactView
    },
    {
      path: '/login',
      name: 'login',
      component: LoginView
    },
    {
      path: '/register',
      name: 'register',
      component: RegisterView
    },
    {
      path: '/cart',
      name: 'cart',
      component: CartView
    }
  ]
})

export default router
