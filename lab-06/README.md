# Helm 

1. Install `helm` by running the following command: `curl https://raw.githubusercontent.com/helm/helm/master/scripts/get-helm-3 | bash`
2. Verify the installation by running the command `helm version --short`
3. Create a new package called `crm` by running the command `helm create crm`
4. Go into the new directory running `cd crm`
5. Run the `tree` command and examine the folder structure.
6. Vim  into the deployment template. Spend 5 minutes trying to understand where the image specification for the containers come from.
7. Go back to the home directory by running `cd` and pressing enter.
8. Create a namespace called `prod`
9. Install the app by running the command `helm install crm ./crm`
10. Check what resources are created. 

