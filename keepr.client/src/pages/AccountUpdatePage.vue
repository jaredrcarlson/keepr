<template>
  <div class="container px-5">
    <div v-if="account.id" class="row mt-3">
      <div class="col-12" align="center">
        <div class="cover-img d-flex flex-column align-items-center">
          <img class="img-fluid" :src="account.coverImg" :alt="account.name" :title="account.name"/>
          <img class="account-img" :src="account.picture" :alt="account.name" :title="account.name">
        </div>
      </div>
    </div>
    <div class="row mt-3">
      <div class="col-12">
        <div class="fs-3 fw-bold">Update Account Info</div>
        <div class="mb-3">
          <label for="name">Name</label>
          <input v-model="data.name" type="text" id="name" name="name" title="Name" class="form-control" minlength="1" maxlength="255">
        </div>
        <div class="mb-3">
          <label for="coverImg">Cover Image</label>
          <input v-model="data.coverImg" type="url" id="coverImg" name="coverImg" title="Cover Image" class="form-control" minlength="1" maxlength="2083">
        </div>
        <div class="mb-3">
          <label for="picture">Profile Picture</label>
          <input v-model="data.picture" type="url" id="picture" name="picture" title="Profile Picture" class="form-control" minlength="1" maxlength="2083">
        </div>
        <div v-if="dataChanged()" class="d-flex justify-content-end">
          <button  @click="resetData()" class="btn tc-white bc-black me-2">Revert Changes</button>
          <button  @click="updateAccount()" class="btn tc-white bc-black">Save Changes</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { ref, computed } from 'vue';
import { useRouter } from 'vue-router';
import { accountService } from '../services/AccountService.js';
import Pop from '../utils/Pop.js';
import { logger } from '../utils/Logger.js';
import { AppState } from '../AppState.js';

export default {
  setup(){
    const data = ref({...AppState.account})
    const router = useRouter()

    async function updateAccount() {
      try {
        await accountService.updateAccount(data.value)
        Pop.success('Account updated successfully')
        router.push({name: 'Account'})
      } catch (error) {
        Pop.error(error.message)
        logger.error(error)
      }
    }

    function dataChanged() {
      const orig = AppState.account
      const curr = data.value
      return orig.name != curr.name || orig.coverImg != curr.coverImg || orig.picture != curr.picture
    }

    function resetData() {
      data.value = {...AppState.account}
    }

    return {
      data,
      account: computed(() => AppState.account),
      updateAccount,
      dataChanged,
      resetData
    }
  }
}
</script>

<style lang="scss" scoped>
.cover-img {
  position: relative;
  max-width: 45vw;
  border-radius: 8px;
}

.account-img {
  position: absolute;
  bottom: -6vh;
  height: 12vh;
  width: 12vh;
  border-radius: 50%;
  object-fit: cover;
  object-position: center;
}
</style>