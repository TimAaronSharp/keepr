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
        myKeeps: []
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
            api('keeps/' + 'user/' + userId)
                .then(res => {
                    commit('setMyKeeps', res.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        }
        //#endregion

    }
})

export default store