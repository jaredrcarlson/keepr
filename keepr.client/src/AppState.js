import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  /** ------ Account ------ */
  /** @type {import('./models/Account.js').Account} */
  account: {},
  /** @type {import('./models/Profile.js').Profile} */
  user: {},
  /** @type {import('./models/Vault.js').Vault[] | null} */
  accountVaults: null,

  /** ------ Profiles ------ */
  /** @type {import('./models/Profile.js').Profile} */
  profile: null,
  /** @type {import('./models/Keep.js').Keep[] | null} */
  profileKeeps: null,
  /** @type {import('./models/Vault.js').Vault[] | null} */
  profileVaults: null,

  /** ------ Keeps ------ */
  /** @type {import('./models/Keep.js').Keep[] | null} */
  keeps: null,
  /** @type {import('./models/Keep.js').Keep | null} */
  keep: null,

  /** ------ Vaults ------ */
  /** @type {import('./models/Vault.js').Vault[] | null} */
  vaults: null,
  /** @type {import('./models/Vault.js').Vault | null} */
  vault: null,

  /** ------ VaultKeeps ------ */
  /** @type {import('./models/VaultKeep.js').VaultKeep[] | null} */
  vaultkeeps: null,
  /** @type {import('./models/VaultKeep.js').VaultKeep | null} */
  vaultkeep: null,

})
