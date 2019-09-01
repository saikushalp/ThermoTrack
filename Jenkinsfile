String stringToPrint = 'foo2'
// 'node' indicates to Jenkins that the enclosed block runs on a node that matches
// the label 'windows-with-vs'
node ('windows-with-vs') {
    // 'stage' is primarily for visualization.  All steps within the stage block
    // show up in the UI under the heading 'Say Hello'.
    stage ('Say Hello') {
        // 'echo' prints the string to the pipeline log file
        // The echoed string is a multi-line string with no inline
        // replacement (single quotes)
        echo '''Hello World.
        This is a Jenkins pipeline.
        '''
    }
    stage ('Run some command') {
        // 'bat' Executes a batch script with the enclodes text.
        // In this case, the enclosed string is a multiline string with
        // inline replacement (double quotes).  The expression inside of ${} will
        // be replaced. Here, it's the stringToPrintVariable.
        bat """type foo > bar.txt
        type ${stringToPrint} >> bar.txt
        """
    }
    stage ('Archive artifacts') {
        // 'archiveArtifacts' Archives artifacts to the server for
        // later.
        archiveArtifacts allowEmptyArchive: false, artifacts: 'bar.txt'
    }
}
