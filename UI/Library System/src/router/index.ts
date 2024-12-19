import { createRouter, createWebHistory } from 'vue-router'
import MediaView from '../views/MediaView.vue'
import StartView from '../views/StartView.vue'
import SingleMediaView from '@/views/SingleMediaView.vue'
import RegisterView from '../views/RegistrationView.vue'
import LogInView from '@/views/LogInView.vue'
import ProfileView from '@/views/ProfileView.vue'
import ReturnView from '@/views/ReturnView.vue'
import LogInValidation from '@/components/LogInView/LogInValidation.vue'
import RegistrationValidation from '@/components/RegistrationView/RegistrationValidation.vue'
import NewsView from '@/views/NewsView.vue'
import HomeView from '@/views/HomeView.vue'
import ChangeQuantity from '@/views/ChangeQuantity.vue'
import moveFormView from '@/views/moveFormView.vue'
import ReservationView from '@/views/ReservationView.vue'
import viewBranchMedia from '@/components/Manage Media/viewBranchMedia.vue'

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
      path: '/change',
      name: 'Change',
      component: ChangeQuantity,
    },
    {
      path: '/move',
      name: 'Move',
      component: moveFormView,
    },
    {
    path: '/reservations',
    name: 'Reservation',
    component: ReservationView,
    },
    {
    path: '/manage',
    name: 'Manage',
    component: viewBranchMedia,
    },
  ],
})

export default router
