import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from '../router'

let api = Axios.create({
    baseURL: window.location.host.includes("localhost") ? 'http://localhost:5000/api/' : '/api/',
    timeout: 2000,
    withCredentials: true
})

let accounts = Axios.create({
    baseURL: window.location.host.includes("localhost") ? 'http://localhost:5000/accounts/' : '/accounts/',
    timeout: 2000,
    withCredentials: true
})

Vue.use(Vuex)

var store = new Vuex.Store({

    state: {
        error: {},
        user: {},
        message: '',
        keeps: [],
        myKeeps: [],
        activeKeep: {},
        myVaults: [],
        activeVault: {},
        myVaultKeeps: [],
        currentVaultsKeeps: [],
        showAllKeeps: false,
        showMyKeeps: false,
        showMyVaults: false,
        showAddToVaults: false,
        showMyVaults: false,
        showShareMessage: false
    },
    mutations: {
        handleError(state, err) {
            state.error = err
        },
        setUser(state, user) {
            state.user = user
        },
        setMessage(state, msg) {
            state.message = msg
        },
        setKeeps(state, keeps) {
            state.keeps = keeps
        },
        setShowMyKeeps(state, showMyKeeps) {
            state.showMyKeeps = !state.showMyKeeps
        },
        setMyKeeps(state, myKeeps) {
            state.myKeeps = myKeeps
        },
        setActiveKeep(state, keep) {
            state.activeKeep = keep
        },
        setShowAllKeeps(state, showAllKeeps) {
            state.showAllKeeps = !state.showAllKeeps
        },
        setMyVaults(state, vaults) {
            state.myVaults = vaults
        },
        setActiveVault(state, vault) {
            state.activeVault = vault
        },
        setAddToVaultsList(state, showAddToVaults) {
            state.showAddToVaults = !state.showAddToVaults
        },
        toggleShowMyVaults(state, toggle) {
            state.showMyVaults = !state.showMyVaults
        },
        setMyVaultKeeps(state, vaultKeeps) {
            state.myVaultKeeps = vaultKeeps
        },
        toggleShareMessage(state, share) {
            state.showShareMessage = !state.showShareMessage
        }
    },
    actions: {

        //#region UserAuth
        authenticate({ commit, dispatch }) {
            accounts('authenticate')
                .then(res => {
                    // console.log("Response @ auth: ", res.data)
                    if (res.data) {
                        commit('setUser', res.data)
                        router.push({ name: "Home" })
                    } else {
                        router.push({ name: "Home" })
                    }
                })
                .catch(() => {
                    router.push({ name: "Home" })
                })
        },
        submitLogin({ commit, dispatch }, user) {
            accounts.post('login', user)
                .then(res => {
                    if (res.data) {
                        commit('setUser', res.data)
                        router.push({ name: "Home" })
                    } else {
                        commit('setMessage', 'No user found.')
                        router.push({ name: "Home" })
                    }
                })
                .catch(err => {
                    commit('handleError', err)
                })
            $('#login-modal').modal('hide')
        },
        submitRegister({ commit, dispatch }, newUser) {
            accounts.post('register', newUser)
                .then(res => {
                    commit('setUser', res.data)
                    commit('setMessage', 'User Registered Successfully!')
                    router.push({ name: "Home" })
                })
                .catch(err => {
                    commit('handleError', err)
                })
            $('#register-modal').modal('hide')
        },
        logout({ commit, dispatch }) {
            accounts.delete('logout')
                .then(res => {
                    commit('setUser', {})
                    router.push({ name: "Home" })
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        //#endregion

        //#region Keeps
        getAllKeeps({ commit, dispatch }) {
            api('keeps')
                .then(res => {
                    commit('setKeeps', res.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        getKeepsByUserId({ commit, dispatch }, userId) {
            api(`keeps/user/${userId}`)
                .then(res => {
                    commit('setMyKeeps', res.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        submitNewKeep({ commit, dispatch }, newKeep) {
            api.post('keeps', newKeep)
                .then(res => {
                    if (res) {
                        commit('setMessage', "New Keep Posted!")
                        dispatch('getAllKeeps')
                    } else {
                        commit('setMessage', "New Keep Post Was Unsuccessful!")
                    }
                })
                .catch(err => {
                    commit('handleError', err)
                })
            $('#post-new-keep-modal').modal('hide')
        },
        incrementKeepValues({ commit, dispatch }, keep) {
            api.put(`keeps/${keep.id}`, keep)
                .then(res => {
                    dispatch('getAllKeeps')
                    dispatch('getKeepsByUserId')
                    commit('setMessage', 'Keep values updated!')
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        showAllKeeps({ commit, dispatch }) {
            commit('setShowAllKeeps')
        },
        showMyKeeps({ commit, dispatch }) {
            commit('setShowMyKeeps')
        },
        setActiveKeep({ commit, dispatch }, keep) {
            commit('setActiveKeep', keep)
        },
        //#endregion

        //#region Vaults
        getVaultsByUserId({ commit, dispatch }, userId) {
            api(`vaults/user/${userId}`)
                .then(res => {
                    commit('setMyVaults', res.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        submitNewVault({ commit, dispatch }, newVault) {
            api.post('vaults', newVault)
                .then(res => {
                    if (res) {
                        commit('setMessage', "New Vault Posted!")
                        dispatch('getVaultsByUserId')
                    } else {
                        commit('setMessage', "New Vault Post Was Unsuccessful!")
                    }
                })
                .catch(err => {
                    commit('handleError', err)
                })
            $('#post-new-vault-modal').modal('hide')
        },
        showMyVaultsList({ commit, dispatch }) {
            commit('toggleShowMyVaults')
        },
        showAddToVaultsList({ commit, dispatch }) {
            commit('setAddToVaultsList')
        },
        setActiveVault({ commit, dispatch }, payload) {
            commit('setActiveVault', payload.vault)
            dispatch('getVaultsByUserId', payload.user.id)
            dispatch('getVaultKeepsByVaultId', payload.vault.id)
        },
        // incrementVaultsAddedTo({ commit, dispatch }, keep) {
        //     api.put(`keeps/${keep.id}`, keep)
        //         .then(res => {
        //             dispatch('getAllKeeps')
        //             commit('setMessage', 'Keep viewed!')
        //         })
        //         .catch(err => {
        //             commit('handleError', err)
        //         })
        // },
        //#endregion

        //#region VaultKeeps
        getVaultKeepsByVaultId({ commit, dispatch }, vaultId) {
            api(`vaultkeeps/${vaultId}`)
                .then(res => {
                    commit('setMyVaultKeeps', res.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        addKeepToVault({ commit, dispatch }, payload) {
            api.post('vaultkeeps', payload)
                .then(res => {
                    if (res) {
                        commit('setMessage', 'Keep Added To Vault!')
                    } else {
                        commit('setMessage', "Keep Was Not Added To Vault!")
                    }
                })
                .catch(err => {
                    commit('handleError', err)
                })
            $('#vault-list').modal('hide')
        },

        //#endregion

        //#region Universal
        removeItem({ commit, dispatch }, payload) {
            api.delete(`${payload.route}/${payload.itemId}`)
                .then(res => {
                    commit('setMessage', res)
                    dispatch(`get${payload.route}ByUserId`, payload.userId)
                    dispatch('getVaultKeepsByVaultId')
                    dispatch('getAllKeeps')
                    dispatch('getKeepsByUserId')

                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        toggleShareMessage({ commit, dispatch }) {
            commit('toggleShareMessage')
        }
        //#endregion

    }
})

export default store