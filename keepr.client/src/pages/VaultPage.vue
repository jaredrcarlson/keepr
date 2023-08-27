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
      <div v-for="keep in vault.keeps" :key="keep.id" class="col-6 col-md-3 mb-3">
        <KeepCard :keep="keep" :modalId="'vaultKeepDetailsModal'" />
      </div>
    </div>

  </div>




</template>

<script>
import { computed, onMounted, onUnmounted } from 'vue';
import { AppState } from '../AppState.js';
import KeepCard from '../components/KeepCard.vue';
import { vaultsService } from '../services/VaultsService.js';
import { useRoute } from 'vue-router';

export default {
  components: { KeepCard },
  setup() {
    const route = useRoute()

    onMounted(() => {
      vaultsService.getById(route.params.vaultId)
    })

    onUnmounted(() => {
      vaultsService.clear()
    })

    return {
      vault: computed(() => AppState.vault)
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
</style>
