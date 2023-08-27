import { AppState } from "../AppState.js";
import { Vault } from "../models/Vault.js";
import { api } from "./AxiosService.js";

class VaultsService {
  async create(data) {
    const res = await api.post('api/vaults', data)
    AppState.vaults.push(new Vault(res.data))
  }

  async getById(id) {
    const res = await api.get(`api/vaults/${id}`)
    AppState.vault = new Vault(res.data)
  }

  async update(id, data) {
    const res = await api.put(`api/vaults/${id}`, data)
    AppState.vault = new Vault(res.data)
    const i = AppState.vaults.findIndex(vault => vault.id == id)
    if (i != -1) {
      AppState.vaults.splice(i, 1, AppState.vault)
    }
  }

  async remove(id) {
    await api.delete(`api/vaults/${id}`)
    AppState.vault = null
    const i = AppState.vaults.findIndex(vault => vault.id == id)
    if (i != -1) {
      AppState.vaults.splice(i, 1)
    }
  }
}
export const vaultsService = new VaultsService();