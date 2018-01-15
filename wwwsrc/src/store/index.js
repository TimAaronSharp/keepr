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
        message: {},
        keeps: [],
        myKeeps: [],
        myVaults: [],
        myVaultKeeps: []
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
        setMyKeeps(state, myKeeps) {
            state.myKeeps = myKeeps
        },
        setMyVaults(state, vaults) {
            state.myVaults = vaults
        },
        setMyVaultKeeps(state, vaultKeeps) {
            state.myVaultKeeps = vaultKeeps
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
        },
        submitRegister({ commit, dispatch }, newUser) {
            accounts.post('register', newUser)
                .then(res => {
                    commit('setUser', res.data)
                    router.push({ name: "Home" })
                })
                .catch(err => {
                    commit('handleError', err)
                })
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
            debugger
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
        },
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
        }

        //#endregion

    }
})

export default store