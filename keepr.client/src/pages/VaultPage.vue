<template>
  <div class="container-fluid">
    <div class="row mt-4 gx-3 mx-4">
      <div v-for="keep in keeps" :key="keep.id" class="col-6 col-md-3">
        <KeepCard :keep="keep" />
      </div>
      <KeepDetailsModal />
    </div>
  </div>
</template>

<script>
import { computed, onUnmounted, watchEffect } from 'vue';
import { AppState } from '../AppState.js';
import { keepsService } from '../services/KeepsService.js';
import KeepCard from '../components/KeepCard.vue';
import KeepDetailsModal from '../components/KeepDetailsModal.vue';
import { vaultsService } from '../services/VaultsService.js';
import { vaultKeepsService } from '../services/VaultKeepsService.js';

export default {
  components: { KeepCard, KeepDetailsModal },
  setup() {

    watchEffect(() => {
      
    })

    onUnmounted(() => {
      // vaultsService.clearVault()
      // vaultKeepsService.clearVaultKeeps()
    })

    return {
      vault: computed(() => AppState.vault),
      keeps: computed(() => AppState.vaultkeeps)
    }
  }
}
</script>

<style scoped lang="scss">

</style>
