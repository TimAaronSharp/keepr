<template>
    <div>
        <button @click="showMyKeepsList(); getKeepsByUserId();">My Keeps</button>
        <div v-if="showMyKeeps">
            <div class="my-keeps-area" v-if="myKeeps.length > 0">
                <div class="my-keeps" v-for="myKeep in myKeeps">
                    {{myKeep.name}} - {{myKeep.description}}
                    <button @click="addToVault">Add to Vault</button>
                    <div v-if="showAddToVaults">
                        <div v-for="myVault in myVaults">
                            <button>{{myVault.name}}</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="my-keeps-area" v-else>
                <p>You have no keeps.</p>
            </div>
        </div>
        <button @click='showKeeps'>Keeps</button>
        <div class="showKeepArea" v-if="showAllKeeps">
            <div v-for="keep in keeps">
                {{keep.name}} - {{keep.description}}
                <button @click="showAddToVaultsList">Add to Vault</button>
                <div v-if="showAddToVaults">
                    <div v-for="vault in myVaults">
                        <button @click="addKeepToVault(user.id, vault.id, keep.id)">{{vault.name}}</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</template>

<script>
    export default {
        name: 'ShowKeeps',
        data() {
            return {
                showAllKeeps: false,
                showMyKeeps: false,
                showAddToVaults: false
            }
        },
        mounted() {
            this.$store.dispatch('getAllKeeps')
            // this.$store.dispatch('getKeepsByUserId', this.user.id)
            // console.log(this.user.id)
        },

        methods: {
            showKeeps() {
                this.showAllKeeps = !this.showAllKeeps
            },
            showMyKeepsList() {
                this.showMyKeeps = !this.showMyKeeps
            },
            showAddToVaultsList() {
                this.showAddToVaults = !this.showAddToVaults
                this.getVaultsByUserId()
            },
            getKeepsByUserId() {
                this.$store.dispatch('getKeepsByUserId', this.user.id)
            },
            getVaultsByUserId() {
                this.$store.dispatch('getVaultsByUserId', this.user.id)
            },
            addKeepToVault(userId, vaultId, keepId) {
                this.$store.dispatch('addKeepToVault', { userId: userId, vaultId: vaultId, keepId: keepId })
            }
        },
        computed: {
            keeps() {
                return this.$store.state.keeps
            },
            myKeeps() {
                return this.$store.state.myKeeps
            },
            myVaults() {
                return this.$store.state.myVaults
            },
            user() {
                return this.$store.state.user
            }
        },
        components: {

        }
    }


</script>

<style>
</style>