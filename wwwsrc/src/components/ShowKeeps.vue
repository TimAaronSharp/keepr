<template>
    <div class="show-keeps-component">

        <button @click="showMyKeepsList(); getKeepsByUserId();">My Keeps</button>

        <div v-if="showMyKeeps">
            <div class="my-keeps-area row text-center" v-if="myKeeps.length > 0 && user.firstName">
                <div class="my-keeps keep col-sm-3 border" v-for="keep in myKeeps">
                    <img class="bl keeps-img" :src="keep.imageURL" alt=""><p class="keep-preview">{{keep.name}} - {{keep.description}}</p>
                    <button @click="showAddToVaultsList">Add to Vault</button>
                    <div v-if="showAddToVaults">
                        <div v-for="vault in myVaults">
                            <button @click="addKeepToVault(user.id, vault.id, keep.id)">{{vault.name}}</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="my-keeps-area" v-else-if="user.firstname && myKeeps.length == 0">
                <p>You have no keeps.</p>
            </div>
            <div class="my-keeps-area" v-else>
                <p>Please login to check your keeps.</p>
            </div>
        </div>

        <button @click='showKeeps'>Keeps</button>

        <div class="all-Keeps-Area row" v-if="showAllKeeps">
            <div class="all-keeps keep col-sm-2 col-sm-offset-1 border text-center block" v-for="keep in keeps">
                <img class="bl keeps-img" :src="keep.imageURL" alt=""> <p class="keep-preview">{{keep.name}} - {{keep.description}}</p>
                <button class="btn btn-default add-to-vault-button" @click="showAddToVaultsList">Add to Vault</button>
                <div v-if="showAddToVaults">
                    <div v-for="vault in myVaults">
                        <button class="btn btn-default add-to-vault-button" @click="addKeepToVault(user.id, vault.id, keep.id)">{{vault.name}}</button>
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

<style scoped>
    .keeps-img {
        margin: auto;
    }
    .keep{
        border-radius: 5px;
        margin-top: 5%;
    }
    .keep:hover{
        background: green;
    }
    .add-to-vault-button{
        background: black;
        color:white;
    }
    .keep-preview{
        font-weight: bold;
    }
    .block{
        display: block;
    }
</style>