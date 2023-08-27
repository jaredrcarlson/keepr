<template>
  
  <nav class="navbar navbar-expand-lg navbar-dark px-3">
    <!-- <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <img alt="logo" src="../assets/img/cw-logo.png" height="45" />
      </div>
    </router-link> -->
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    
    <div class="collapse navbar-collapse d-flex justify-content-between" id="navbarText">
      <div>
        <div class="navbar-nav me-auto">
            <router-link :to="{ name: 'Home' }" class="btn selectable">
              Home
            </router-link>
          
            <select @change="openModal()" v-model="modalId" class="bc-pale border-0 selectable" aria-label="Create Keep or Vault" required>
              <option selected value="none">Create</option>
              <option value="newKeepModal">Keep</option>
              <option value="newVaultModal">Vault</option>
            </select>
        </div>
      </div>
      <div>
        <img alt="logo" src="../assets/img/keeper-logo.png" height="45" />
      </div>
      <div>
        <Login />
      </div>

    </div>
  </nav>
</template>

<script>
import { ref } from 'vue';
import Login from './Login.vue';
import { Modal } from 'bootstrap';
export default {
  setup() {
    const modalId = ref("none")
    return {
      modalId,
      openModal() {
        if(modalId.value != 'none') {
          Modal.getOrCreateInstance(`#${modalId.value}`).show()
          modalId.value = 'none'
        }
      }
    }
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

nav {
  border-bottom: 3px solid lightgray;
}

.nav-link {
  text-transform: uppercase;
}

/* .navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
} */

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>
