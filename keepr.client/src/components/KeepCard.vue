<template>
  <!-- <div class="keep-card elevation-4" :style="{ backgroundImage: `url(${keep.img})` }"> -->
  <div @click="openKeepModal(keep, modalId)" class="keep-card elevation-4 selectable">
    <img class="keep-img img-fluid" :src="keep.img" :alt="keep.name" :title="keep.name"/>
    <div class="keep-content">
      <div class="d-flex justify-content-between align-items-center">
        <p class="tc-white m-0 p-2 fs-5">{{ keep.name }}</p>
        <img class="creator-img m-2" :src="keep.creator.picture" :alt="keep.creator.name" :title="keep.creator.name">
      </div>
    </div>
  </div>
</template>


<script>
import { Modal } from 'bootstrap';
import { Keep } from '../models/Keep.js';
import { keepsService } from '../services/KeepsService.js';
import { accountService } from '../services/AccountService.js';
import { AppState } from '../AppState.js';

export default {
  props: {
    keep: {type: Keep, required: true},
    modalId: {type: String, required: true}
  },

  setup(){
    return {
      openKeepModal(keep, modalId) {
        keepsService.setKeep(keep)
        if(AppState.account.id) {
          accountService.getAccountVaults()
        }
        keepsService.update(keep.id, {views: ++keep.views})
        Modal.getOrCreateInstance(`#${modalId}`).show()
      }
    }
  }

}
</script>


<style lang="scss" scoped>
.keep-card {
  position: relative;
  border-radius: 8px;
}

.keep-img {
  border-radius: 8px;
}

.keep-content {
  position: absolute;
  bottom: 8px;
}



// .creator-img{
//   height: 5vh;
//   width: 5vh;
//   border-radius: 50%;
//   object-fit: cover;
//   object-position: center;
// }

// @media(min-width: 768px){
//   .creator-img{
//     height: 7vh;
//     width: 7vh;
//     border-radius: 50%;
//     object-fit: cover;
//     object-position: center;
//   }
// }
</style>