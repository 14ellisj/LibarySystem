import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import MediaView from '../views/MediaView.vue'
import StartView from '../views/StartView.vue'
import SingleMediaView from '@/views/SingleMediaView.vue'
import RegisterView from '../views/RegistrationView.vue'
import LogInView from '@/views/LogInView.vue'
import ProfileView from '@/views/ProfileView.vue'
import WishlistView from '@/views/WishlistView.vue'
import ReturnView from '@/views/ReturnView.vue'
import LogInValidation from '@/components/LogInView/LogInValidation.vue'
import RegistrationValidation from '@/components/RegistrationView/RegistrationValidation.vue'
import AboutPage from '@/views/AboutPage.vue'
import NewsView from '@/views/NewsView.vue'
import ReturnedView from '@/views/ReturnedView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: "/",
      redirect: { path: "/home" },
    },
    {
      path: '/home',
      name: 'home',
      component: AboutPage,
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
      path: '/item',
      name: 'Item',
      component: SingleMediaView,
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
      path: '/registrationValidation',
      name: 'registrationValidation',
      component: RegistrationValidation,
    },
    {
      path: '/news',
      name: 'News',
      component: NewsView,
    },
    {
      path: '/returned',
      name: 'Returned',
      component: ReturnedView,
    }
  ],
})

export default router
