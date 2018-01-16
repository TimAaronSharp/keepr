<template>
    <div class="show-keeps-component ilb">

        <button @click="showMyKeepsList(); getKeepsByUserId();" class="btn btn-primary custom-btn">My Keeps</button>

        <div v-if="showMyKeeps">
            <div class="my-keeps-area row text-center" v-if="myKeeps.length > 0 && user.firstName">
                <div class="my-keeps keep col-sm-3 border" v-for="keep in myKeeps">
                    <img class="bl keeps-img" :src="keep.imageURL" alt="">
                    <p class="keep-preview">{{keep.name}} - {{keep.description}}</p>
                    <button @click="showAddToVaultsList">Add to Vault</button>
                    <i class="fa fa-eye icons">{{keep.views}}</i>
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

        <button @click='bus.$on(keep-area, 1)' class="btn btn-primary custom-btn">Keeps</button>


    </div>

</template>

<script>
    import Vue from 'vue'
    export default {
        name: 'ShowKeeps',
        data() {
            return {

                showMyKeeps: false,
                showAddToVaults: false
            }
        },
        mounted() {

            var bus = new Vue()
            
            // this.$store.dispatch('getKeepsByUserId', this.user.id)
            // console.log(this.user.id)
        },

        methods: {

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
            },
            incrementKeepViews(keep) {
                keep.views++
                this.$store.dispatch('incrementKeepViews', keep)
            }
        },
        computed: {

            myKeeps() {
                return this.$store.state.myKeeps
            },
            myVaults() {
                return this.$store.state.myVaults
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

    .keep {
        border-radius: 5px;
        margin-top: 5%;
    }

    .keeps-img:hover {
        background: green;
    }

    .add-to-vault-button {
        background: black;
        color: white;
    }

    .keep-preview {
        font-weight: bold;
    }

    .icons {
        color: black;
        margin-right: 1rem;
    }
</style>