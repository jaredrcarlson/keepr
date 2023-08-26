<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer></footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

$color0: #F9F6FA;
$color1: #FEF6F0;
$color2: #E9D8D6;
$color3: #DED6E9;
$color4: #877A8F;
$color5: #2D2D2D; 

.tc-white{
  color: $color0;
}

.tc-pale{
  color: $color1;
}

.tc-peach{
  color: $color2;
}

.tc-light-purple{
  color: $color3;
}

.tc-dark-purple{
  color: $color4;
}

.tc-black{
  color: $color5;
}

.bc-white{
  background-color: $color0;
}

.bc-pale{
  background-color: $color1;
}

.bc-peach{
  background-color: $color2;
}

.bc-light-purple{
  background-color: $color3;
}

.bc-dark-purple{
  background-color: $color4;
}

.bc-black{ 
  background-color: $color5;
}

:root{
  --main-height: calc(100vh - 32px - 64px);
}

header, body{
  background-color: $color1;
}



</style>
