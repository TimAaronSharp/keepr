<template>
    <div class="vault-component ilb">

        <div v-if="showMyVaults">
            <div class="my-vaults-area" v-if="myVaults.length > 0 && user.firstName">

                <div class="my-vaults" v-for="myVault in myVaults">
                    <span class="vault" @click="showVaultKeepsList(); getVaultKeepsByVaultId(myVault.id); setActiveVault(myVault)">{{myVault.name}}</span>
                    <span class="vault-btns-span pull-right">
                        <i @click="removeItem(myVault.id, 'Vaults')" class="fa fa-trash remove-btn"></i>
                    </span>

                    <div v-if="showMyVaultKeeps">
                        <div v-if="activeVault.id == myVault.id">
                            <div class="my-vaultkeeps-area row" v-if="myVaultKeeps.length > 0">
                                <div class="vault-keep col-sm-12 bl" v-for="myVaultKeep in myVaultKeeps">
                                    <span class="pull-left vault-keep-in-list">
                                        <img class="vault-keep-img " :src="myVaultKeep.imageURL" alt=""> {{myVaultKeep.name}}</span>
                                    <span class="vault-btns-span pull-right">
                                        <i @click="removeItem(myVaultKeep.keepId, 'Keeps')" class="fa fa-trash remove-btn"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="my-vaults-area" v-else-if="user.firstName && myVaults.length == 0">
                <p>You have no vaults.</p>
            </div>
            <div v-else>
                <p>This vault has no keeps.</p>
            </div>
        </div>

    </div>

</template>

<script>
    export default {
        name: 'Vault',
        data() {
            return {

                showMyVaultKeeps: false
            }
        },
        // mounted() {
        //   this.checkUser()
        // },
        methods: {

            showVaultKeepsList() {
                this.showMyVaultKeeps = !this.showMyVaultKeeps
            },
            getVaultKeepsByVaultId(vaultId) {
                this.$store.dispatch('getVaultKeepsByVaultId', vaultId)
            },
            removeItem(itemId, route) {
                this.$store.dispatch('removeItem', { itemId: itemId, route: route, userId: this.user.id })
            },
            removeItemFromVault(itemId) {
                this.$store.dispatch('removeItemFromVault', { itemId: itemId, route: route })
            },
            setActiveVault(vault) {
                this.$store.dispatch('setActiveVault', { vault: vault, user: this.user })
            }



        },
        computed: {
            user() {
                return this.$store.state.user
            },
            currentVaultsKeeps() {
                return this.$store.state.currentVaultsKeeps
            },
            myVaults() {
                return this.$store.state.myVaults
            },
            myVaultKeeps() {
                return this.$store.state.myVaultKeeps
            },
            showMyVaults() {
                return this.$store.state.showMyVaults
            },
            activeVault() {
                return this.$store.state.activeVault
            }
        },
        components: {
        }
    }

</script>

<style scoped>
    .vault-keep {
        color: white;
        font-size: 2rem;
    }

    .vault-keep-img {
        max-width: 50px;
    }

    .my-vaults {
        margin-left: 2%;
    }

    .remove-btn {
        color: white;
        font-size: 2.5rem;

    }

    .vault-keep-in-list {
        margin-left: 15%;
    }

    .remove-btn:hover {
        cursor: pointer;
    }

    .vault-btns-span {
        padding-top: 5.5%;
        /* padding-bottom: 34%; */
    }

    .vault-keep:hover,
    .vault:hover {
        cursor: pointer;
    }
</style>