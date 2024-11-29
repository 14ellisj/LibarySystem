import { createRouter, createWebHistory } from 'vue-router'
import MediaView from '../views/MediaView.vue'
import StartView from '../views/StartView.vue'
import RegisterView from '../views/RegistrationView.vue'
import LogInView from '@/views/LogInView.vue'
import ProfileView from '@/views/ProfileView.vue'
import WishlistView from '@/views/WishlistView.vue'
import ReturnView from '@/views/ReturnView.vue'
import LogInValidation from '@/components/LogInView/LogInValidation.vue'
import HomeView from '@/views/HomeView.vue'
import NewsView from '@/views/NewsView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      redirect: { path: '/home' },
    },
    {
      path: '/home',
      name: 'home',
      component: HomeView,
    },
    {
      path: '/media',
      name: 'Media',
      component: MediaView,
    },
    {
      path: '/front',
      name: 'Front',
      component: StartView,
    },
    {
      path: '/register',
      name: 'Register',
      component: RegisterView,
    },
    {
      path: '/login',
      name: 'Log In',
      component: LogInView,
    },
    {
      path: '/profile',
      name: 'Profile',
      component: ProfileView,
    },
    {
      path: '/wishlist',
      name: 'WishList',
      component: WishlistView,
    },
    {
      path: '/return',
      name: 'Return',
      component: ReturnView,
    },
    {
      path: '/logInValidation',
      name: 'logInValidation',
      component: LogInValidation,
    },
    {
      path: '/news',
      name: 'News',
      component: NewsView,
    },
  ],
})

export default router
