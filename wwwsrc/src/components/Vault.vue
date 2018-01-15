<template>
    <div class="vault">
        <button @click="showMyVaultsList(); getVaultsByUserId();">My Vaults</button>
        <div v-if="showMyVaults">
            <div class="my-vaults-area" v-if="myVaults.length > 0">
                <div class="my-vaults" v-for="myVault in myVaults">
                    <button @click="showVaultKeepsList(); getVaultKeepsByVaultId(myVault.id);">{{myVault.name}}</button>
                </div>
                <div v-if="showMyVaultKeeps">
                    <div class="my-vaultkeeps-area" v-if="myVaultKeeps.length > 0">
                        <div class="my-vaultkeeps" v-for="myVaultKeep in myVaultKeeps">
                            {{myVaultKeep.name}} - {{myVaultKeep.description}}
                        </div>
                    </div>
                </div>
            </div>
            <div class="my-vaults-area" v-else>
                <p>You have no vaults.</p>
            </div>
        </div>
    </div>

</template>

<script>
    export default {
        name: 'Vault',
        data() {
            return {
                showMyVaults: false,
                showMyVaultKeeps: false
            }
        },
        // mounted() {
        //   this.checkUser()
        // },
        methods: {
            showMyVaultsList() {
                this.showMyVaults = !this.showMyVaults
            },
            showVaultKeepsList() {
                this.showMyVaultKeeps = !this.showMyVaultKeeps
            },
            getVaultsByUserId() {
                this.$store.dispatch('getVaultsByUserId', this.user.id)
            },
            getVaultKeepsByVaultId(vaultId) {
                this.$store.dispatch('getVaultKeepsByVaultId', vaultId)
            }


        },
        computed: {
            user() {
                return this.$store.state.user
            },
            myVaults() {
                return this.$store.state.myVaults
            },
            myVaultKeeps() {
                return this.$store.state.myVaultKeeps
            }
        },
        components: {
        }
    }

</script>

<style>
</style>