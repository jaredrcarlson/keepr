<template>
  <div class="vault-card elevation-4">
    <img class="img-fluid" :src="vault.img" :alt="vault.name"/>
    <div class="vault-content d-flex justify-content-between align-items-center">
      <p class="tc-white m-0 p-2 fs-5">{{ vault.name }}</p>
      <div v-if="vault.isPrivate" class="bc-white lock d-flex align-items-center justify-content-center">
        <i class="mdi mdi-lock"></i>
      </div>
      
    </div>
  </div>
</template>


<script>
import { Vault } from '../models/Vault.js';

export default {
  props: {
    vault: {type: Vault, required: true}
  },

  setup(){
    return {}
  }
  
}
</script>


<style lang="scss" scoped>
.vault-card {
  position: relative;
  border-radius: 5px;
}

.vault-content {
  position: absolute;
  bottom: 8px;
}

.creator-img{
  height: 5vh;
  width: 5vh;
  border-radius: 50%;
  object-fit: cover;
  object-position: center;
}

@media(min-width: 768px){
  .creator-img{
    height: 7vh;
    width: 7vh;
    border-radius: 50%;
    object-fit: cover;
    object-position: center;
  }
}

.lock{
  height: 4vh;
  width: 4vh;
  border-radius: 50%;
}
</style>