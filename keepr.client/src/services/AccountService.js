import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { Vault } from '../models/Vault.js'
import { logger } from '../utils/Logger'
import Pop from '../utils/Pop.js'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getAccountVaults() {
    const res = await api.get('/account/vaults')
    AppState.accountVaults = res.data.map(data => new Vault(data))
  }
}

export const accountService = new AccountService()
