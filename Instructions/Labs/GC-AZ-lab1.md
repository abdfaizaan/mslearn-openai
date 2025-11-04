# Lab 01: Generate and improve code with Azure OpenAI Service

### Estimated Duration: 120 Minutes

## Lab scenario
The Azure OpenAI Service models can generate code for you using natural language prompts, fixing bugs in completed code, and providing code comments. These models can also explain and simplify existing code to help you understand what it does and how to improve it.

## Lab objectives
In this lab, you will complete the following tasks:

- Task 1: Deploy a model
- Task 2: Generate code in chat playground
- Task 3: Set up an application in Cloud Shell
- Task 4: Configure your application
- Task 5: Run your application
  
## Task 1: Deploy a model

To use the Azure OpenAI API for code generation, you must first deploy a model to use through the **Azure OpenAI Studio**. Once deployed, we will use the model with the playground and reference that model in our app.

1. In the **Azure portal**, search for **OpenAI** and select **Azure OpenAI**.

   ![](../media/msi-image2.png)

1. On **AI Foundry | Azure OpenAI** blade, select **openai-<inject key="DeploymentID" enableCopy="false"></inject>**

   ![](../media/rm4.png)

1. To capture the Keys and Endpoints values, on **openai-<inject key="DeploymentID" enableCopy="false"></inject>** blade:
      - Select **Keys and Endpoint (1)** under **Resource Management**.
      - Click on **Show Keys (2)**.
      - Copy **Key 1 (3)** and ensure to paste it into a text editor such as Notepad for future reference.
      - Finally, copy the **Endpoint (4)** API URL by clicking on copy to clipboard. Paste it in a text editor such as Notepad for later use.

        ![](../media/openai-endpoint-new.png "Keys and Endpoints")

1. In the Azure OpenAI resource pane, click on **Go to Azure AI Foundry portal** and it will navigate to **Azure AI Foundry portal**.

      ![](../media/openaige8.png)

1. In the **Deployments (1)** page, click on **+ Deploy model** , Choose **Deploy base Model (2)**.

      ![](../media/Openai-04.png)

1. Search **gpt-4o-mini**, **select (2)** it and click on **Confirm (3)**.

      ![](../media/openge1.png)

1. Within the **Deploy model** pop-up interface, enter the following details:

    - **Deployment name**: gpt-4o-mini **(1)**
    - **Deployment type**: Standard **(2)**
    -  Select **Customize** **(3)**

        ![](../media/openge2.png)
       
1. Within the **Deploy model** pop-up interface, enter the following details:
    - **Deployment name**: gpt-4o-mini **(1)**
    - **Deployment type**: Standard **(2)**
    - **Model Version**: 2024-07-18(Default) **(3)**
    - **Tokens per Minute Rate Limit (thousands)**: 10K **(4)**
    - **Content Filter**: Default **(5)**
    - **Enable dynamic quota**: Enabled **(6)**
    - Click on **Deploy** (7)

        ![](../media/openge3.png)

   > **Note**:You can ignore the "Failed to fetch deployments quota information" notification.

> **Congratulations** on completing the task! Now, it's time to validate it. Here are the steps:
> - Hit the Validate button for the corresponding task. If you receive a success message, you can proceed to the next task. 
> - If not, carefully read the error message and retry the step, following the instructions in the lab guide.
> - If you need any assistance, please contact us at cloudlabs-support@spektrasystems.com. We are available 24/7 to help you out.

  <validation step="4a0f2d4d-175a-4dc9-8700-484bc47d1f3f" />
  
## Task 2: Generate code in chat playground

Before using in your app, examine how Azure OpenAI can generate and explain code in the chat playground.

1. On your **gpt-4o-mini** model, click on **Open in playground**.

      ![](../media/gpt-4-open-in-playground.png)

1. In the **Chat session**, enter the following prompt and press *Enter*.

      ```code
      Write a function in python that takes a character and string as input, and returns how many times that character appears in the string
      ```

      ![](../media/gpt-4-chat-session.png)
        
1. The model will likely respond with a function, with some explanation of what the function does and how to call it.
   
1. Next, send the prompt `Do the same thing, but this time write it in C#`.
   
1. Observe the output. The model likely responded very similarly as the first time, but this time coding in C#. You can ask it again 
   for a different language of your choice, or a function to complete a different task such as reversing the input string.
   
1. Next, let's explore using AI to understand code. Submit the following prompt as the user message.

      ```code
       What does the following function do?  
       ---  
       def multiply(a, b):  
       result = 0  
       negative = False  
       if a < 0 and b > 0:  
           a = -a  
           negative = True  
       elif a > 0 and b < 0:  
           b = -b  
           negative = True  
       elif a < 0 and b < 0:  
           a = -a  
           b = -b  
       while b > 0:  
           result += a  
           b -= 1      
       if negative:  
           return -result  
       else:  
           return result
      ```   

1. Observe the output, which explains what the function does, which is to multiply two numbers together by using a loop.

1. Submit the prompt `Can you simplify the function?`. The model should write a simpler version of the function.

1. Submit the prompt: `Add some comments to the function.` The model adds comments to the code.
    
## Task 3: Set up an application in Cloud Shell

To show how to integrate with an Azure OpenAI model, we'll use a short command-line application that runs in Cloud Shell on Azure. Open up a new browser tab to work with Cloud Shell.

1. In the [Azure portal](https://portal.azure.com?azure-portal=true), select the **[>_]** (*Cloud Shell*) button at the top of the page 
   to the right of the search box. A Cloud Shell pane will open at the bottom of the portal.

      ![](../media/Openai-08.png)

1. The first time you open the Cloud Shell, you may be prompted to choose the type of shell you want to use (Bash or PowerShell). Select Bash. If you don't see this option, skip the step.

      ![](../media/Openai-09.png)

1. Within the Getting Started pane, select Mount **storage account (1)**, select your Storage account **subscription (2)** from the dropdown 
   and **click Apply (3)**.

      ![](../media/Openai-10.png)

1. Within the Mount storage account pane, select I want to create a **storage account** **(1)** and click **Next** **(2)**.

      ![](../media/Openai-11.png)

1. Within the Advanced settings pane, enter the following details:

      - Subscription: Default- Choose the only existing subscription assigned for this lab (1).
      - Resource group: Select **openai-<inject key="DeploymentID" enableCopy="false"></inject>** **(2)**
      - Region: Select  **<inject key="Region" enableCopy="false" />** **(3)**
      - Storage account: Select **storage<inject key="DeploymentID" enableCopy="false"></inject>** **(4)**
      - File share: Create a new file share named **blob<inject key="DeploymentID" enableCopy="false"></inject>** **(5)**
      - Click **Create (6)**

        ![](../media/Openai-12.png)

1. Once the terminal starts, enter the following command to download the sample application and save it to a folder called `azure-openai`.

      ```bash
      rm -r azure-openai -f
      git clone https://github.com/MicrosoftLearning/mslearn-openai azure-openai
      ```

      >**NOTE:** If you get a message saying already cloned, please move to the next step.

1. The files are downloaded to a folder named **azure-openai**. Navigate to the lab files for this exercise using the following command.

      ```bash
      cd azure-openai/Labfiles/01-app-develop
      ```

      >**NOTE:** Applications for both C# and Python have been provided, as well as sample code we'll be using in this lab.

1. Open the built-in code editor, and you can observe the code files we'll be using in `sample-code`. Use the following command to open the lab files in the code editor.

      ```bash
      code .
      ```
   
      > **NOTE:** If you're prompted to **Switch to Classic Cloud Shell** after running the **code .** command, click on **Confirm** and make sure you are in the correct project path.

      ![](../media/classic-cloudshell-prompt.png)

1. Repeat the commands you executed in steps 7 and 8 for the language of your preference.


<validation step="d2e1f993-b207-40be-9554-9ece30e830a9" />

> **Congratulations** on completing the task! Now, it's time to validate it.
> - Hit the Validate button for the corresponding task. If you receive a success message, you can proceed to the next task. 
> - If not, carefully read the error message and retry the step, following the instructions in the lab guide.
> - If you need any assistance, please contact us at cloudlabs-support@spektrasystems.com. We are available 24/7 to help you out.

## Task 4: Configure your application

For this exercise, you will complete some key parts of the application to enable using your Azure OpenAI resource.

1. Use the appropriate command below based on your chosen programming language.

1. Enter the following command to edit the configuration file that has been provided.

      - **C#**: `code appsettings.json`
      - **Python**: `code .env`

1. Update the configuration values to include:
   
    - The **endpoint** and **key** that you copied in Notepad from the Azure OpenAI resource.
    - The **deployment name** for your model deployment: **gpt-4o-mini**.
    - Press **Ctrl + S** to save the file.
    - To exit the code editor: Press **Ctrl + Q**.

      - Navigate to the folder for your preferred language and install the necessary packages.

        **C#**
   
        ```bash
        cd azure-openai/Labfiles/01-app-develop
        cd CSharp
        dotnet add package Azure.AI.OpenAI --version 2.1.0
        ```

        **Python**
   
        ```bash
        cd azure-openai/Labfiles/01-app-develop
        cd Python
        pip install --user openai==1.65.2
        pip install python-dotenv --user
        ```

1. Add code to use the Azure OpenAI service.

   Enter the following command to edit the provided code file for your preferred programming language:

    **Python**

    ```
   code application.py
    ```

    **C#**

    ```
   code Program.cs
    ```

1. In the code editor, replace the comment ***Add Azure OpenAI package*** with code to add the Azure OpenAI SDK library:

    **Python**

    ```python
    # Add Azure OpenAI package
    from openai import AsyncAzureOpenAI
    ```

    **C#**

    ```csharp
    // Add Azure OpenAI packages
    using Azure.AI.OpenAI;
    using OpenAI.Chat;
    ```

1. In the code file, find the comment ***Configure the Azure OpenAI client***, and add code to configure the Azure OpenAI client:

    **Python**

    ```python
   # Configure the Azure OpenAI client
   client = AsyncAzureOpenAI(
       azure_endpoint = azure_oai_endpoint, 
       api_key=azure_oai_key,  
       api_version="2024-02-15-preview"
   )
    ```

    **C#**

    ```csharp
   // Configure the Azure OpenAI client
   AzureOpenAIClient azureClient = new (new Uri(oaiEndpoint), new ApiKeyCredential(oaiKey));
   ChatClient chatClient = azureClient.GetChatClient(oaiDeploymentName);
    ```

1. In the function that calls the Azure OpenAI model, under the comment ***Get response from Azure OpenAI***, add the code to format and send the request to the model.

    **Python**

    ```python
   # Get response from Azure OpenAI
   messages =[
       {"role": "system", "content": system_message},
       {"role": "user", "content": user_message},
   ]
    
   print("\nSending request to Azure OpenAI model...\n")

   # Call the Azure OpenAI model
   response = await client.chat.completions.create(
       model=model,
       messages=messages,
       temperature=0.7,
       max_tokens=800
   )
    ```

    **C#**

    ```csharp
   // Get response from Azure OpenAI
   ChatCompletionOptions chatCompletionOptions = new ChatCompletionOptions()
   {
       Temperature = 0.7f,
       MaxOutputTokenCount = 800
   };

   ChatCompletion completion = chatClient.CompleteChat(
       [
           new SystemChatMessage(systemMessage),
           new UserChatMessage(userMessage)
       ],
       chatCompletionOptions
   );

   Console.WriteLine($"{completion.Role}: {completion.Content[0].Text}");
    ```

1. Save the changes to the code file by pressing **Ctrl + S**.
1. To exit the editor, press **Ctrl + Q**. 
   
   >**Note**: Please make sure the indentation is correct and matches the code above before moving to the next task.
          
1. To save the changes made to the file, right-click on the file from the left pane, and hit **Save**

## Task 5: Run your application

Now that your app has been configured, run it to send your request to your model and observe the response. You'll notice the only difference between the different options is the content of the prompt, all other parameters (such as token count and temperature) remain the same for each request.

1. In the folder of your preferred language, open system.txt using: `code system.txt`.

1. Enter the System message for the current iteration and save the file: `Ctrl + S` → `Ctrl + Q`

1. From the below iteration, the System message prompt should be saved in `system.txt`.

1. In the interactive terminal pane, ensure the folder context is the folder for your preferred language. Then enter the following command to run the application.

    - **Python**: `python application.py`
    - **C#**: `dotnet run`

1. If you encounter an error when running **dotnet run**:
   ```code
      You must install or update .NET to run this application.
      ```
1. Navigate to the folder containing your C# project and open CSharp.csproj: `code CSharp.csproj`.

1. Update the target framework
   - Find the following line in the file: 
   ```code
      <TargetFramework>net8.0</TargetFramework>
      ```
   - Change it to: 
   ```code
      <TargetFramework>net9.0</TargetFramework>
      ```

1. Press **Ctrl + S** to save , then **Ctrl + Q** to close the file.

1. In the terminal, run: `dotnet build`.

1. Then run: `dotnet run`.

1. Once the app is running, enter the **User message** prompt in the terminal.

   > **Tip**: You can maximize the panel size in the terminal toolbar to see more of the console text.

1. For the first iteration, enter the following prompts:

    **System message**

    ```prompt
   You are an AI assistant
    ```

1. **Press any key to continue** when prompted by the application.

    **User message:**

    ```prompt
   Write an intro for a new wildlife Rescue
    ```

1. Observe the output. The AI model will likely produce a good generic introduction to a wildlife rescue.

1. To exit the application, type quit and press Enter.
   
1. Next, enter the following prompts which specify a format for the response:

    **System message**

    ```prompt
   You are an AI assistant helping to write emails
    ```

    **User message:**

    ```prompt
   Write a promotional email for a new wildlife rescue, including the following: `
   - Rescue name is Contoso `
   - It specializes in elephants `
   - Call for donations to be given at our website
    ```

    > **Tip**: You may find the automatic typing in the VM doesn't work well with multiline prompts. If that is your issue, copy the entire prompt then paste it into the terminal.

1. Observe the output. This time, you'll likely see the format of an email with the specific animals included, as well as the call for donations.
   
1. Next, enter the following prompts that additionally specify the content:

    **System message**

    ```prompt
   You are an AI assistant helping to write emails
    ```

    **User message:**

    ```prompt
   Write a promotional email for a new wildlife rescue, including the following: `
   - Rescue name is Contoso `
   - It specializes in elephants, as well as zebras and giraffes `
   - Call for donations to be given at our website `
   Include a list of the current animals we have at our rescue after the signature, in the form of a table. These animals include elephants, zebras, gorillas, lizards, and jackrabbits.
    ```

1. Observe the output, and see how the email has changed based on your clear instructions.
   
1. Next, enter the following prompts where we add details about tone to the system message:

    **System message**

    ```prompt
   You are an AI assistant that helps write promotional emails to generate interest in a new business. Your tone is light, chit-chat oriented and you always include at least two jokes.
    ```

    **User message:**

    ```prompt
   Write a promotional email for a new wildlife rescue, including the following: `
   - Rescue name is Contoso `
   - It specializes in elephants, as well as zebras and giraffes `
   - Call for donations to be given at our website `
   Include a list of the current animals we have at our rescue after the signature, in the form of a table. These animals include elephants, zebras, gorillas, lizards, and jackrabbits.
    ```

1. Observe the output. This time you'll likely see the email in a similar format, but with a much more informal tone. You'll likely even see jokes included!

## Summary

By completing this lab, you’ve gained hands-on experience with Azure OpenAI Service models, demonstrating how AI can be a powerful tool in code generation, bug fixing, and code comprehension. You’ve learned to deploy models, utilize the Chat Playground for code-related tasks, and integrate AI into a real-world application through Azure Cloud Shell. Additionally, you've explored the capabilities of the DALL-E model for image generation. These skills will help you leverage AI to enhance your coding workflow, making development more efficient and insightful.

## Review

In this lab, you have accomplished the following:
-   Provision an Azure OpenAI resource
-   Deploy an OpenAI model within the Azure OpenAI studio
-   Use the functionalites of the Azure OpenAI to generate and improvise code for your production applications.

## You have successfully completed the lab. Click on Next >> to procced with next exercise.
