import { createRouter, createWebHashHistory } from 'vue-router'
import { authGuard, authSettled } from '@bcwdev/auth0provider-client'

function loadPage(page) {
  return () => import(`./pages/${page}.vue`)
}

const routes = [
  {
    path: '/',
    name: 'Home',
    component: loadPage('HomePage'),
    beforeEnter: authSettled
  },
  {
    path: '/account',
    name: 'Account',
    component: loadPage('AccountPage'),
    beforeEnter: authGuard
  },
  {
    path: '/accountupdate',
    name: 'Account Update',
    component: loadPage('AccountUpdatePage'),
    beforeEnter: authGuard
  },
  {
    path: '/vault/:vaultId',
    name: 'Vault',
    component: loadPage('VaultPage'),
    beforeEnter: authSettled
  },
  {
    path: '/profile/:profileId',
    name: 'Profile',
    component: loadPage('ProfilePage'),
    beforeEnter: authSettled
  }
]

export const router = createRouter({
  linkActiveClass: 'router-link-active',
  linkExactActiveClass: 'router-link-exact-active',
  history: createWebHashHistory('/keepr/'),
  routes
})
