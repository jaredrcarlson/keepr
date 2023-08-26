<template>
  <!-- <div class="keep-card elevation-4" :style="{ backgroundImage: `url(${keep.img})` }"> -->
  <div class="keep-card elevation-4">
    <img class="img-fluid" :src="keep.img" :alt="keep.name"/>
    <div class="keep-content d-flex justify-content-between align-items-center">
      <p class="tc-white m-0 p-2 fs-5">{{ keep.name }}</p>
      <img class="creator-img m-2" :src="keep.creator.picture" :alt="keep.creator.name">
    </div>
  </div>
</template>


<script>
import { Keep } from '../models/Keep.js';

export default {
  props: {
    keep: {type: Keep, required: true}
  },

  setup(){
    return {}
  }

}
</script>


<style lang="scss" scoped>
.keep-card {
  position: relative;
  border-radius: 5px;
}

.keep-content {
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
</style>