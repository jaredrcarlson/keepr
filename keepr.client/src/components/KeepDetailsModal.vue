<template>
  <div id="keepDetailsModal" class="modal fade" tabindex="-1" aria-labelledby="keepDetailsModal" aria-hidden="true">
    <div class="modal-dialog modal-lg modal-dialog-centered">
        <div v-if="keep" class="bc-pale modal-content container-fluid rounded">
            <div class="row bc-pale rounded">
              
              <div class="col-12 col-md-6">
                <img class="keep-img" :src="keep.img" :alt="keep.name" :title="keep.name">  
              </div>
              
              <div class="col-12 col-md-6 py-3 d-flex flex-column justify-content-between">
                
                <div class="d-flex justify-content-center text-muted">
                    <span class="me-4"><i class="mdi mdi-eye me-2"></i>{{ keep.views }}</span>
                    <span><i class="mdi mdi-alpha-k-box me-2"></i>{{ keep.kept }}</span>
                </div>
                <div class="px-3"> 
                  <div class="text-center fw-bold fs-5">{{ keep.name }}</div>
                  <div>{{ keep.description }}</div>
                </div>
                <div class="d-flex justify-content-between align-items-center">
                  <div>
                    <select v-model="selectedVault" class="bc-pale border-0 selectable me-2" aria-label="Create Keep or Vault" required>
                      <option v-for="vault in vaults" :key="vault.id" :value="vault">{{ vault.name }}</option>
                    </select>
                    <button @click="createVaultKeep(keep)" class="btn btn-sm tc-white bc-dark-purple">Save</button>
                  </div>
                  <div class="d-flex align-items-center">
                    <img class="creator-img me-2" :src="keep.creator.picture" :alt="keep.creator.name" :title="keep.creator.name">
                    <div class="pe-1">{{ keep.creator.name }}</div>
                  </div>
                </div>
              </div>
            </div>
        </div>
    </div>
  </div>
</template>

<script>
import { computed, onBeforeMount, ref } from 'vue';
import { AppState } from '../AppState.js';
import { accountService } from '../services/AccountService.js';
import { vaultKeepsService } from '../services/VaultKeepsService.js';
import { VaultKeep } from '../models/VaultKeep.js';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
import { keepsService } from '../services/KeepsService.js';

export default {
  setup(){
    const selectedVault = ref({})

    async function createVaultKeep(keep) {
      try {
        await vaultKeepsService.create({vaultId: selectedVault.value.id, keepId: keep.id})
        await keepsService.update(keep.id, {kept: ++keep.kept})
      } catch (error) {
        logger.log(error)
        Pop.error(error.message)
      }
    }

    // onBeforeMount(() => {
    //   accountService.getAccountVaults()
    // })

    return {
      selectedVault,
      keep: computed(() => AppState.keep),
      vaults: computed(() => AppState.accountVaults),
      createVaultKeep
    }
  }
}
</script>


<style lang="scss" scoped>
.keep-img {
  width: 100%;
  height: auto;
  object-position: center;
}
</style>