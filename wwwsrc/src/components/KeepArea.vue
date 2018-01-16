<template>
    <div class="pull-right">
        <!-- <h1>HEY THEREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE</h1>
            <h1>HEY THERE</h1>
            <h1>HEY THERE</h1>
            <h1>HEY THERE</h1> -->
        <div class="all-Keeps-Area row" id="keep-area" v-if="showAllKeeps">
            <div class="all-keeps keep col-sm-2 col-sm-offset-1 border text-center bl" id="keep-area" v-for="keep in keeps">
                <img class="bl keeps-img" :src="keep.imageURL" alt="">
                <p class="keep-preview">{{keep.name}} - {{keep.description}}</p>
                <button @click="incrementKeepViews(keep)">
                    <i class="fa fa-eye icons"></i>
                </button>
                <div class="wrapper bl">
                    <i class="fa fa-eye">{{keep.views}}</i>
                    <i class="fa fa-fort-awesome">{{keep.vaultsAddedTo}}</i>
                </div>
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
    import Vue from 'vue'
    export default {
        name: 'KeepArea',
        data() {
            return {
                showAllKeeps: false


            }
        },
        mounted() {
            this.$store.dispatch('getAllKeeps')
            var bus = new Vue()
            bus.$emit('keep-area', getAllKeeps())
        },

        methods: {
            showKeeps() {
                this.showAllKeeps = !this.showAllKeeps
            },
            getAllKeeps() {
                this.$store.dispatch('getAllKeeps')
            }

        },
        computed: {
            keeps() {
                return this.$store.state.keeps
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
    .keep-area {
        border: 2px solid black;
        width: 75%;
    }
</style>