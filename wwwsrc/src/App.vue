<template>
  <div id="app">
    <!-- <Error></Error>
    <Message></Message> -->
    <router-view/>
  </div>
</template>

<script>
  import Error from './components/Error'
  import Message from './components/Message'
  export default {
    name: 'app',
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch('authenticate')
    },
    components: {
      Error,
      Message
    }
  }
</script>

<style>
  #app {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    /* margin-top: 60px; */
    overflow: hidden;
  }

  .vault {
    color: white;
    font-size: 4rem;
    overflow: scroll;
    background: #fa0296;
  }

  .bl {
    display: block;
  }

  .ilb {
    display: inline-block;
  }

  /* .border {
    border: 2px solid black;
  } */
  p{
    font-weight:bold;
  }
  .custom-btn {
    background: black;
    color: white;
    border: 0;
    border-radius: 5px;
    font-size: 1.4rem;
    font-weight: bold;
  }
  img{
    border-radius:5px;
  }

  .account-btn {
    padding-top: 1.3%;
    /* padding-bottom: 34%; */
    margin-right: 2%;
  }

  .cursor:hover {
    cursor: pointer;
  }

  .btn-no-border {
    border: 0;
    background: none;
    position: absolute;
    display: none;
  }

  .hover-btns:hover button {
    display: inline-block;
  }
</style>