<template>
    <div class="all-keeps-area pull-right">
        <!-- <h1>HEY THEREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE</h1>
        <h1>HEY THERE</h1>
        <h1>HEY THERE</h1>
        <h1>HEY THERE</h1> -->
        <!-- <h1>STILL NEED TO GET MY VAULTS WORKING AGAIN. SHOULD I TRY TO MOUNT ALL THE VAULTS AND VAULTKEEPS AND JUST TOGGLE, OR RUN IT WHEN YOU CLICK THE BUTTON?</h1> -->



        <div v-if="showMyKeeps">
            <div class="my-keeps-area row text-center" v-if="myKeeps.length > 0 && user.firstName">
                <div class="my-keeps keep col-sm-3 col-sm-offset-1 border" v-for="keep in myKeeps">
                    <img class="bl keeps-img" :src="keep.imageURL" alt="">
                    <p class="keep-preview">{{keep.name}}</p>
                    <span class="vault-btns-span pull-right">
                        <i @click="removeItem(keep.id, 'Keeps')" class="fa fa-trash cursor"></i>
                    </span>
                    <div class="wrapper bl">
                        <i class="fa fa-eye icons">{{keep.views}}</i>
                        <i class="fa fa-fort-awesome">{{keep.vaultsAddedTo}}</i>
                    </div>
                    <button @click="showAddToVaultsList">Add to Vault</button>
                    <div v-if="showAddToVaults">
                        <div v-for="vault in myVaults">
                            <button @click="addKeepToVault(user.id, vault.id, keep.id); incrementVaultsAddedTo(keep);">{{vault.name}}</button>
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

        <div class="all-Keeps-Area row" id="keep-area" v-if="showAllKeeps">
            <div class="all-keeps keep col-sm-3 col-sm-offset-1 border text-center bl" v-for="keep in keeps">
                <img class="bl keeps-img" :src="keep.imageURL" alt="">
                <p class="keep-preview">{{keep.name}}</p>
                <button class="btn-no-border view-btn hidden" @click="incrementKeepViews(keep)">
                    <img src="../assets/view-btn.png">
                </button>
                <button class="btn-no-border keep-btn hidden" @click="showAddToVaultsList">
                    <img src="../assets/keep-btn.png">
                </button>
                <button class="btn-no-border share-btn hidden">
                    <img src="../assets/share-btn.png">
                </button>
                <div class="wrapper bl">
                    <i class="">{{keep.views}}</i>
                    <i class="fa fa-fort-awesome">{{keep.vaultsAddedTo}}</i>
                </div>
                <div v-if="showAddToVaults">
                    <div v-for="vault in myVaults">
                        <button class="btn btn-default add-to-vault-button" @click="addKeepToVault(user.id, vault.id, keep.id); incrementVaultsAddedTo(keep);">{{vault.name}}</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</template>

<script>
    import Vue from 'vue'
    export default {
        name: 'KeepArea',
        data() {
            return {


            }
        },
        mounted() {
            this.$store.dispatch('getAllKeeps')
            // this.runShowKeeps()

        },

        methods: {
            // runShowKeeps() {
            //     var bus = new Vue()
            //     bus.$on("#keep-area", this.showKeeps())
            // },
            // showKeeps() {
            //     this.showAllKeeps = !this.showAllKeeps

            //     console.log("IT WORKED")
            // },
            getAllKeeps() {
                this.$store.dispatch('getAllKeeps')
            },
            showAddToVaultsList() {
                this.$store.dispatch("showAddToVaultsList")
                this.getVaultsByUserId()
            },
            incrementKeepViews(keep) {
                keep.views++
                this.$store.dispatch('incrementKeepValues', keep)
            },
            getVaultsByUserId() {
                this.$store.dispatch('getVaultsByUserId', this.user.id)
            },
            addKeepToVault(userId, vaultId, keepId) {
                this.$store.dispatch('addKeepToVault', { userId: userId, vaultId: vaultId, keepId: keepId })
            },
            incrementVaultsAddedTo(keep) {
                keep.vaultsAddedTo++
                this.$store.dispatch('incrementKeepValues', keep)
            },
            removeItem(itemId, route) {
                this.$store.dispatch('removeItem', { itemId: itemId, route: route, userId: this.user.id })
            },

        },
        computed: {
            keeps() {
                return this.$store.state.keeps
            },
            myKeeps() {
                return this.$store.state.myKeeps
            },
            user() {
                return this.$store.state.user
            },
            showAllKeeps() {
                return this.$store.state.showAllKeeps
            },
            showAddToVaults() {
                return this.$store.state.showAddToVaults
            },
            myVaults() {
                return this.$store.state.myVaults
            },
            showMyKeeps() {
                return this.$store.state.showMyKeeps
            }

        },
        components: {

        }
    }

</script>

<style scoped>
    .all-keeps-area {
        border: 2px solid black;
        width: 75%;
        overflow-wrap: break-word;
        padding-right: 5%;
        margin-top: 5%;
    }

    .all-keeps {
        position: relative;
    }

    .keep {
        margin-top: 2.5%;
        margin-bottom: 2.5%;
    }

    .keeps-img {
        margin: auto;
    }
    .view-btn{
        top: 2%;
        left: 25%;
    }
    .keep-btn{
        top: 2%;
        right: 25%;

    }
    .share-btn{
        top: 31%;
        left: 38%;

    }

    .add-to-vault-button {
        background: #fa0296;
        color: white;
    }
</style>