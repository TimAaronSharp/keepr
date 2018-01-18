<template>
    <div class="all-keeps-area pull-right">
        <div class="row "v-if="showMyKeeps">
            <div class="hover-btns br all-keeps keep col-sm-3 col-sm-offset-1 text-center bl keep-text" v-for="myKeep in myKeeps">
                <img class="bl keeps-img" :src="myKeep.imageURL" alt="">
                <p class="keep-preview">{{myKeep.name}}</p>
                <button type="button" class="btn-no-border view-btn" data-toggle="modal" data-target="#keep-view" @click="getKeepsByUserId(); incrementKeepViews(myKeep); setActiveKeep(myKeep);">
                    <img src="../assets/view-btn.png">
                </button>
                <button class="btn-no-border keep-btn" data-toggle="modal" data-target="#vault-list" @click="getKeepsByUserId(); setActiveKeep(myKeep);">
                    <img src="../assets/keep-btn.png">
                </button>
                <button class="btn-no-border share-btn" id="share-effect" @click="toggleShareMessage">
                    <img src="../assets/share-btn.png">
                </button>
                <div class="wrapper bl">
                    <i class="fa fa-eye">{{myKeep.views}}</i>
                    <i class="fa fa-fort-awesome">{{myKeep.vaultsAddedTo}}</i>
                    <span class="vault-btns-span pull-right">
                        <i @click="removeItem(myKeep.id, 'Keeps')" class="fa fa-trash remove-btn"></i>
                    </span>
                </div>
                <!-- <div v-if="showAddToVaults">
                            <div v-for="vault in myVaults">
                                <button class="btn btn-default add-to-vault-button" @click="addKeepToVault(user.id, vault.id, keep.id); incrementVaultsAddedTo(keep);">{{vault.name}}</button>
                            </div>
                        </div> -->
            </div>
        </div>
        <div class="my-keeps-area" v-else-if="user.firstname && myKeeps.length == 0">
            <p>You have no keeps.</p>
        </div>

        <div class="all-Keeps-Area row" id="keep-area" v-if="showAllKeeps">
            <div class="hover-btns br all-keeps keep col-sm-3 col-sm-offset-1 text-center bl keep-text" v-for="keep in keeps">
                <img class="bl keeps-img" :src="keep.imageURL" alt="">
                <p class="keep-preview">{{keep.name}}</p>
                <button type="button" class="btn-no-border view-btn" data-toggle="modal" data-target="#keep-view" @click="incrementKeepViews(keep); setActiveKeep(keep);">
                    <img src="../assets/view-btn.png">
                </button>
                <button class="btn-no-border keep-btn" data-toggle="modal" data-target="#vault-list" @click="getVaultsByUserId(); setActiveKeep(keep);">
                    <img src="../assets/keep-btn.png">
                </button>
                <button class="btn-no-border share-btn" id="share-effect" @click="toggleShareMessage">
                    <img src="../assets/share-btn.png">
                </button>
                <div class="wrapper bl">
                    <i class="fa fa-eye">{{keep.views}}</i>
                    <i class="fa fa-fort-awesome">{{keep.vaultsAddedTo}}</i>
                </div>
                <!-- <div v-if="showAddToVaults">
                    <div v-for="vault in myVaults">
                        <button class="btn btn-default add-to-vault-button" @click="addKeepToVault(user.id, vault.id, keep.id); incrementVaultsAddedTo(keep);">{{vault.name}}</button>
                    </div>
                </div> -->
            </div>
        </div>
        <div v-if="activeKeep.name">
            <div class="modal fade" id="keep-view" tabindex="-1" role="dialog" aria-labelledby="keep-view">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-body keep-text">


                            <img :src="this.activeKeep.imageURL" alt="">
                            <p>{{this.activeKeep.name}}</p>
                            <p>{{this.activeKeep.description}}</p>


                            <button type="button" class="btn btn-default" data-dismiss="modal">Back</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="vault-list" tabindex="-1" role="dialog" aria-labelledby="vault-list">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-body custom-btn">

                        <img class="add-to-vault-preview" :src="this.activeKeep.imageURL" alt="">
                        <p>{{this.activeKeep.name}}</p>
                        <p>Add to which vault?</p>

                        <div class="row">
                            <div class="add-to-vault-button text-center col-sm-12" v-for="myVault in myVaults">

                                <span @click="addKeepToVault(user.id, myVault.id, activeKeep.id); incrementVaultsAddedTo(activeKeep);">{{myVault.name}}</span>

                            </div>
                        </div>

                        <!-- <p>{{this.activeVault.name}}</p> -->

                        <button type="button" class="btn btn-default" data-dismiss="modal">Back</button>
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
                chooseVault: false
            }
        },
        mounted() {
            this.$store.dispatch('getAllKeeps')
            this.$store.dispatch('showAllKeeps')
        },

        methods: {
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
            setActiveKeep(keep) {
                this.$store.dispatch('setActiveKeep', keep)
            },
            chooseVaults() {
                this.chooseVault = !this.chooseVault
            },
            toggleShareMessage() {
                this.$store.dispatch('toggleShareMessage')
            }
        },
        computed: {
            keeps() {
                return this.$store.state.keeps
            },
            myKeeps() {
                return this.$store.state.myKeeps
            },
            activeKeep() {
                return this.$store.state.activeKeep
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
        /* border: 2px solid black; */
        width: 75%;
        overflow-wrap: break-word;
        padding-right: 5%;
        margin-top: 5%;
    }

    .add-to-vault-preview {
        width: 20%;
    }

    .all-keeps {
        position: relative;
    }

    .keep {
        padding-top: 2.5%;
        margin-top: 2.5%;
        margin-bottom: 2.5%;
    }

    .br {
        border-radius: 5%;
    }

    .keeps-img {
        margin: auto;
    }

    .view-btn {
        top: 2%;
        left: 25%;
    }

    .keep-btn {
        top: 2%;
        right: 25%;

    }

    .share-btn {
        top: 31%;
        left: 38%;
    }

    .keep-text {
        background: black;
        color: white;
    }

    .add-to-vault-button {
        color: white;
        font-size: 5rem;
        background: #fa0296;
        margin: 0;
    }
</style>