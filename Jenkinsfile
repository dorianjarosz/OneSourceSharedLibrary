import jenkins.model.Jenkins
import hudson.model.*
import com.cloudbees.groovy.cps.NonCPS

@NonCPS
def updateVersion(String jobName){
    def jenkins = Jenkins.getInstance()
    String versionType = "minor"
    def job = jenkins.getItemByFullName(jobName)


    def paramsDef = job.getProperty(ParametersDefinitionProperty.class)
    if (paramsDef) {
       paramsDef.parameterDefinitions.each{
           if("version".equals(it.name)){
                def splitVersion = it.defaultValue.split('\\.')
                int minorVar = splitVersion[1]
                if ( minorVar > 8){
                    splitVersion[1] = 0
                    it.defaultValue = splitVersion.join('.')
                    versionType = "major"
                }
                   
                }

               it.defaultValue = getUpdatedVersion(versionType, it.defaultValue)
           
           }
       }
    }
   

@NonCPS
def getUpdatedVersion(String versionType, String currentVersion){

    def split = currentVersion.split('\\.')
        switch (versionType){
            case "minor.minor":
                split[2]=++Integer.parseInt(split[2])
                break
            case "minor":
                split[1]=++Integer.parseInt(split[1])
                break;
            case "major":
                split[0]=++Integer.parseInt(split[0])
                break;
        }
        return split.join('.')
}

pipeline {
    agent any

    environment {
        HOME = '/tmp'
    }
	   stages{
      
        stage('Creating Package') {
            steps {
                bat 'dotnet build'
                bat 'dotnet pack "OneSourceSharedLibrary.csproj"'
		echo "Packed"
            }
        }
        stage('Push Package'){
            steps{
                bat 'dotnet nuget push "${WORKSPACE}/bin/Debug/OneSourceSharedLibrary.${version}.nupkg" -k 12345 -s  http://localhost:5000/v3/index.json  --skip-duplicate'
            }
        }
        stage('Update Version'){
            steps{
                updateVersion("${JOB_NAME}")
                cleanWs()

            }
        }
		
	}
	
}