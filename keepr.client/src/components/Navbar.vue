<template>
  
  <nav class="navbar navbar-expand-lg navbar-dark px-3">
    <!-- <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <img alt="logo" src="../assets/img/cw-logo.png" height="45" />
      </div>
    </router-link> -->
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    
    <div class="collapse navbar-collapse d-flex justify-content-between" id="navbarText">
      <div>
        <div class="navbar-nav me-auto">
            <router-link :to="{ name: 'Home' }" class="btn">
              <div class="bc-peach rounded selectable">
                <div class="px-3 py-1">Home</div>
              </div>
            </router-link>
          
            <!-- <select @change="openModal()" v-model="modalId" class="bc-pale border-0 selectable" aria-label="Create Keep or Vault" required>
              <option selected value="none">Create</option>
              <option value="newKeepModal">Keep</option>
              <option value="newVaultModal">Vault</option>
            </select> -->

            <div class="dropdown my-2 my-lg-0">
              <!-- <div type="button" class="border-0 selectable no-select" data-bs-toggle="dropdown" aria-expanded="false">
                Create
              </div> -->
              <div class="create-btn border-0" data-bs-toggle="dropdown">
                <div class="ms-1 mt-2 pt-1">Create<i class="mdi mdi-menu-down"></i></div>
              </div>
              <div class="dropdown-menu dropdown-menu-start p-0" aria-labelledby="authDropdown">
                <div class="list-group">
                  <div @click="openModal('newKeepModal')" class="new-btn dropdown-item list-group-item-action selectable">
                    new keep
                  </div>
                  <div @click="openModal('newVaultModal')" class="new-btn dropdown-item list-group-item-action selectable">
                    new vault
                  </div>

                </div>
              </div>
            </div>

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
      // openModal() {
      //   if(modalId.value != 'none') {
      //     Modal.getOrCreateInstance(`#${modalId.value}`).show()
      //     modalId.value = 'none'
      //   }
      // }
      openModal(name) {
        if(name != 'none') {
          Modal.getOrCreateInstance(`#${name}`).show()
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
