<template>
  <div v-if="vault" class="container px-5">
    <div class="row mt-3">
      <div class="col-12" align="center">
        <div class="vault-img d-flex flex-column align-items-center">
          <img class="img-fluid" :src="vault.img" :alt="vault.name" :title="vault.name"/>
          <div class="tc-white vault-content">
            <div class="fs-4 fw-bold">
              {{ vault.name }}
            </div>
            <div class="">
              by {{ vault.creator.name }}
            </div>
          </div>
          <div class="vault-delete" v-if="user.isAuthenticated && user.id == vault.creatorId">
            <button @click="deleteVault(vault)" class="btn btn-sm tc-white bg-danger">Delete</button>
          </div>
        </div>
      </div>
    </div>
    <div class="row mt-4">
      <div class="col-12 d-flex flex-column align-items-center">
        <div class="text-muted">
          {{ vault.keeps.length }} Keeps
        </div>
      </div>
    </div>
    <div class="row mt-4 gx-3 mx-4">
      <!-- <div v-for="keep in vault.keeps" :key="keep.id" class="col-6 col-md-3 mb-3">
        <KeepCard :keep="keep" :modalId="'vaultKeepDetailsModal'" />
      </div> -->
      <div class="col-12">
        <KeepMasonryWall :keepsSource="'vault.keeps'" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, onUnmounted } from 'vue';
import { AppState } from '../AppState.js';
import KeepCard from '../components/KeepCard.vue';
import { vaultsService } from '../services/VaultsService.js';
import { useRoute, useRouter } from 'vue-router';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';

export default {
  components: { },
  setup() {
    const route = useRoute()
    const router = useRouter()

    onMounted(async() => {
      const response = await vaultsService.getById(route.params.vaultId)
      if(response.status != 200) {
        Pop.error('Unauthorized')
        router.push({name: 'Home'})
      }
    })

    async function deleteVault(vault) {
      try {
        await vaultsService.remove(vault.id)
        Pop.success(`'${vault.name}' deleted successfully`)
        router.push({name: 'Profile', params: {profileId: vault.creatorId}})
      } catch (error) {
        Pop.error(error.message)
        logger.error(error)
      }
    }

    onUnmounted(() => {
      vaultsService.clear()
    })

    return {
      user: computed(() => AppState.user),
      vault: computed(() => AppState.vault),
      deleteVault
    }
  }
}
</script>

<style scoped lang="scss">
.vault-img {
  position: relative;
  border-radius: 8px;
}

.vault-content {
  position: absolute;
  bottom: 8px;
}

.vault-delete {
  position: absolute;
  top: 8px;
}
</style>
