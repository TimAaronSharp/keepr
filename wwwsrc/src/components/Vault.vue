<template>
    <div class="vault ilb">
        <button @click="showMyVaultsList(); getVaultsByUserId();" class="btn btn-primary custom-btn custom-btn">My Vaults</button>
        <div v-if="showMyVaults">
            <div class="my-vaults-area" v-if="myVaults.length > 0 && user.firstName">
                <div class="my-vaults" v-for="myVault in myVaults">
                    <button @click="showVaultKeepsList(); getVaultKeepsByVaultId(myVault.id);">{{myVault.name}}</button>
                </div>
                <div v-if="showMyVaultKeeps">
                    <div class="my-vaultkeeps-area" v-if="myVaultKeeps.length > 0">
                        <div class="my-vaultkeeps" v-for="myVaultKeep in myVaultKeeps">
                            {{myVaultKeep.name}} - {{myVaultKeep.description}}
                        </div>
                    </div>
                    <div v-else>
                        <p>This vault has no keeps.</p>
                    </div>
                </div>
            </div>
            <div class="my-vaults-area" v-else-if="user.firstName && myVaults.length == 0">
                <p>You have no vaults.</p>
            </div>
            <div class="my-vaults-area" v-else>
                <p>Please login to view vaults.</p>
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