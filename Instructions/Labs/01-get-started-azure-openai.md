# Lab 01: Get started with Azure OpenAI Service

### Estimated Duration: 120 Minutes

Azure OpenAI Service brings the generative AI models developed by OpenAI to the Azure platform, enabling you to develop powerful AI solutions that benefit from the security, scalability, and integration of services provided by the Azure cloud platform. In this exercise, you'll learn how to get started with Azure OpenAI by provisioning the service as an Azure resource and using the Azure AI Foundry portal to deploy and explore OpenAI models.

## Lab Objectives
In this lab, you will complete the following tasks:

- Task 1: Provision an Azure OpenAI resource
- Task 2: Deploy a model
- Task 3: Explore a model in the Completions playground
- Task 4: Use the Chat playground
- Task 5: Explore prompts and parameters 
- Task 6: Explore code generation

## Task 1: Provision an Azure OpenAI resource

In this task, you'll create an Azure resource in the Azure portal, selecting the OpenAI service and configuring settings such as region and pricing tier. This setup allows you to integrate OpenAI's advanced language models into your applications.

1. In the **Azure portal**, search for **OpenAI (1)** and select **Azure OpenAI (2)**.

   ![](../media/select-openai-1607.png)

2. On **AI Foundry | Azure OpenAI** blade, click on **+ Create**.

   ![](../media/180625(01).png)

3. Create an **Azure OpenAI** resource using the specified settings. Leave all other options at their default values, and click **Next (6)** three times to proceed through the remaining steps.
   
    - Subscription: Default - Pre-assigned subscription **(1)**
    - Resource group: **openai-<inject key="DeploymentID" enableCopy="false"></inject> (2)**
    - Region: Select **Sweden Central (3)**
    - Name: **OpenAI-Lab01-<inject key="DeploymentID" enableCopy="false"></inject> (4)**
    - Pricing tier: **Standard S0 (5)**
  
      ![](../media/nlpe1.png "Create Azure OpenAI resource")

      >**Note:** **Please deploy Openai resource in Swedencentral Region**.

4. Review all the configured settings to ensure they are correct. Once confirmed, click on the **Create** button to begin the deployment of your Azure OpenAI resource.

     ![](../media/180625(02).png "Create Azure OpenAI resource")
     

5. Wait for deployment to complete. Then go to the deployed Azure OpenAI resource in the Azure portal.

> **Congratulations** on completing the task! Now, it's time to validate it. Here are the steps:
> - Hit the Validate button for the corresponding task. If you receive a success message, you can proceed to the next task. 
> - If not, carefully read the error message and retry the step, following the instructions in the lab guide. 
> - If you need any assistance, please contact us at cloudlabs-support@spektrasystems.com. We are available 24/7 to help you out.

<validation step="1fa0e87b-eb46-463d-b63b-edf6e2282e16" />

## Task 2: Deploy a model

In this task, you'll deploy a specific AI model instance within your Azure OpenAI resource to integrate advanced language capabilities into your applications.

1. In the **Azure portal**, search for **OpenAI (1)** and select **Azure OpenAI (2)**.

   ![](../media/select-openai-1607.png)

1. On the **AI Foundry | Azure OpenAI** page, select **OpenAI-Lab01-<inject key="DeploymentID" enableCopy="false"></inject>**

   ![](../media/180625(03).png)

1. In the Azure OpenAI resource page, click on **Go to Azure AI Foundry portal**, which will navigate to the **Azure AI Foundry portal**.

   ![](../media/goto-aiportal-1607.png)

1. On the **Azure AI Foundry portal** page, select **Deployments (1)** under **Shared resources** from the left pane. Then, click **+ Deploy Model (2)** and choose **Deploy base model (3)**.

   ![](../media/deploy-model-1607.png)

1. On the Select a model page, search for **gpt-4o-mini (1)**, then select **gpt-4o-mini (2)**, and then click on **Confirm (3)**

   ![](../media/select-gpt-model-1607.png)

1. Click on **Customize**.
   
   ![](../media/get-started-openai-lab1-6.png)   

1. Within the **Deploy model** pop-up interface, enter the following details:

      - Deployment name: **my-gpt-model (1)**
      - Deployment type: **Standard(2)**
      - Model version: **2024-07-18(default) (3)**
      - Tokens per Minute Rate Limit (thousands): **8K (4)**
      - Content Filter: **DefaultV2 (5)**
      - Enable dynamic quota: **Enabled (6)**
      - Click on **Deploy** **(7)**
  
           ![](../media/get-started-openai-lab1-2.png)

           >**Note**: gpt-4o-mini is supported only for chat completions, and it is not supported for completions API.

1. **Click the back arrow** on the newly created model, then select **Deployments (1)** under **Shared Resources** in the left pane. After that, click **+ Deploy Model (2)** and choose **Deploy base model (3)**.

      ![](../media/back-to-deployments-1607.png)

      ![](../media/deploy-model-1607.png)

1. On the Select a model page, search for **gpt-35-turbo-instruct (1)**, then select **gpt-35-turbo-instruct (2)**, and then click on **Confirm (3)**.

   ![](../media/select-turbo-model-1607.png)

1. Click on **Customize**.

   ![](../media/get-started-openai-lab1-7.png)
   
1. Within the **Deploy model** pop-up interface, enter the following details:
      - Deployment name: **gpt-35-turbo-instruct (1)**
      - Deployment type: **Standard(2)**
      - Model version: **0914 (Default) (3)**
      - Tokens per Minute Rate Limit (thousands): **20K (4)**
      - Content Filter: **DefaultV2 (5)**      
      - Enable dynamic quota: **Enabled (6)**
      - Click on **Deploy** (7)
  
        ![](../media/get-started-openai-lab1-3.png)

1. These will deploy models that you can experiment with for both chat and completion tasks as you go along.

      > **Note**: You can ignore any error related to the assignment of roles to view the quota limits. 

   
   > **Congratulations** on completing the task! Now, it's time to validate it. Here are the steps
   > - Hit the Validate button for the corresponding task. If you receive a success message, you can proceed to the next task. 
   > - If not, carefully read the error message and retry the step, following the instructions in the lab guide.
   > - If you need any assistance, please contact us at cloudlabs-support@spektrasystems.com. We are available 24/7 to help you out.

   <validation step="3b4a472e-f956-45d8-b828-3e2cc01c2e88" />

## Task 3: Explore a model in the Completions playground

In this task, you'll explore a model in the Completions playground that involves interacting with the AI model to test and refine its responses using real-time input and output examples.

1. In Azure OpenAI Foundry, in the left pane under **Playgrounds (1)**, select **Completions (2)**.

   ![](../media/select-completions-1607.png)

2. In the **Completions** page, ensure your **gpt-35-turbo-instruct (1)** deployment is selected for the Deployments, and paste the below prompt in the **Prompt (2)** section and click on **Generate (3)**.

   ```
   Generate a quiz of 5 questions. For each question, provide me with the answer options and the correct answer
   ```
      ![](../media/L1T3S2-1607.png)

      >**Note:** The summarised text sample consists of a *prompt* that provides some text to tell the model what kind of response is required and includes some contextual information.

3. The response consists of a quiz based on the example in the prompt.

    ![](../media/nls101.png)

   >**Note:** The output of the chat may vary. The screenshot is provided for reference only and may not reflect the exact same output.

   >**Note**: You can use the **Regenerate** button to resubmit the prompt(new changes have been made), and note that the response may vary from the original one. A generative AI model can produce new language each time it's called.

4. At the bottom of the page, note the number of *tokens* detected in the text. Tokens are the basic units of a prompt - essentially, words or word parts in the text.

5. Use the **View Code** button to view the code that a client application would use to submit the prompt. You can select your preferred programming language. The prompt contains the text you submitted to the model. The request is submitted to the *Completions* API for your Azure OpenAI service.

      ![](../media/NO-3a.png)

      ![](../media/L1T3S5.2-1407.png)
    
6. Close the **Sample Code**.

## Task 4: Use the Chat playground

In this task, you'll use the Chat playground to interact with and test the AI model's conversational abilities through a simulated chat interface.

1. In the **Playground** section from the left pane, select the **Chat (1)** option. Ensure that the **my-gpt-model (2)** model is selected for the Deployments.

   ![](../media/get-started-openai-lab1-5.png)

1. In the **Setup** section, in the **Give the model instructions and context (1)** box, replace the current text with the below statement, and click on **Apply changes (2)** and subsequently click on **Continue** in **Update system message?** pop-up window.

   ```
   The system is an AI teacher that helps people learn about AI
   ```

      ![](../media/L1T4S2-1607.png)

      ![](../media/L1T4S3-1407.png)
   
1. In the **Setup** section, Click on **Add section** box, then click on **Examples**.

      ![](../media/L1T4S3-1607.png)

1. Enter the following message and response in the designated boxes:

      - **User (1)**:
        ```
        What are the different types of artificial intelligence?
        ```
    
      - **Assistant (2)**:
        ```
        There are three main types of artificial intelligence: Narrow or Weak AI (such as virtual assistants like Siri or Alexa, image recognition software, and spam filters), General or Strong AI (AI designed to be as intelligent as a human being. This type of AI does not currently exist and is purely theoretical), and Artificial Superintelligence (AI that is more intelligent than any human being and can perform tasks that are beyond human comprehension. This type of AI is also purely theoretical and has not yet been developed).
        ``` 

         ![](../media/L1T4S4-1607.png)
   
         > **Note**: Few-shot examples are used to provide the model with examples of the types of responses that are expected. The model will attempt to reflect the tone and style of the examples in its own responses.

1. Save the changes by clicking on **Apply changes** and subsequently click on **Continue** to start a new session and set the behavioural context of the chat system.

      ![](../media/L1T4S5.1-1607.png)

      ![](../media/L1T4S3-1407.png)
   
1. In the query box at the bottom of the page, enter the below-mentioned text **(1)**. Use the **Send (2)** button to submit the message and view the response.

   ```
   What is artificial intelligence?
   ```

   ![](../media/L1T4S6-1607.png)
   
      > **Note**: You may receive a response that the API deployment is not yet ready. If so, wait for a few minutes and try again.

1. Review the response.

   ![](../media/L1T4S7-1407.png)

1. Then submit the following message to continue the conversation:

   ```
   `How is it related to machine learning?`
   ```

1. Review the response, noting that context from the previous interaction is retained (so the model understands that "it" refers to artificial intelligence).

1. Use the **View Code** button to view the code for the interaction. The prompt consists of the *system* message, the few-shot examples of *user* and *assistant* messages, and the sequence of *user* and *assistant* messages in the chat session so far.

      ![](../media/image5a.png)

### Task 5: Explore prompts and parameters

In this task, you'll explore prompts and parameters by experimenting with different inputs and settings to fine-tune the AI model's responses and behavior.

1. In the **Chat Configuration** pane select **ParameterS (1)** , set the following parameter values:
      
      - **Max response**: 500 **(2)**
     
      - **Temperature**: 0 **(3)**
   
          ![](../media/image6.png)
      
2. **Submit (2)** the following message in a chat session **(1)**

      ```
      Write three multiple-choice questions based on the following text.

      Most computer vision solutions are based on machine learning models that can be applied to visual input from cameras, videos, or images.*

      - Image classification involves training a machine learning model to classify images based on their contents. For example, in a traffic monitoring solution, you might use an image classification model to classify images based on the type of vehicle they contain, such as taxis, buses, cyclists, and so on.*

      - Object detection machine learning models are trained to classify individual objects within an image and identify their location with a bounding box. For example, a traffic monitoring solution might use object detection to identify the location of different classes of vehicles.*

      - Semantic segmentation is an advanced machine learning technique in which individual pixels in the image are classified according to the object to which they belong. For example, a traffic monitoring solution might overlay traffic images with "mask" layers to highlight different vehicles using specific colors.
      
      ```

      ![](../media/L1T5S2-1607.png)

3. Review the results, which should consist of multiple-choice questions that a teacher could use to test students on the computer vision topics in the prompt. The total response should be smaller than the maximum length you specified as a parameter.

      ![](../media/last-3.jpg)
   
4. Observe the following about the prompt and parameters you used:

      - The prompt specifically states that the desired output should be three multiple-choice questions.
       
      - The parameters include *Temperature*, which controls the degree to which response generation includes an element of randomness. The value of **0** used in your submission minimizes randomness, resulting in stable, predictable responses.

### Task 6: Explore code generation

In this task, you'll explore code generation by testing the AI model’s ability to generate and suggest code snippets based on various programming prompts and requirements.

1. In the **Setup pane**, under the **System message**, enter the system message: `You are a Python developer.` **(1)** then save the changes by clicking on **Apply changes (2)** and click on **Continue** when prompted.

      ![](../media/L1T6S1-1607.png)

      ![](../media/L1T4S3-1407.png)

2. In the **Chat session** pane, select the **Clear chat** button, then select **Clear** from the pop-up window to clear the chat history and start a new session.

      ![](../media/clear-history-1607.png)

      ![](../media/L1T6S2.2-1407.png)

4. Submit the following user message:

      ```
      Write a Python function named Multiply that multiplies two numeric parameters.
      ```

5. Review the response, which should include sample Python code that meets the requirement in the prompt.

     ![](../media/task-6-lasta.png)

## Summary

- In this lab, you provisioned an **Azure OpenAI resource** to integrate generative AI capabilities into your applications.
- You **deployed two models** (gpt-4o-mini for chat and gpt-35-turbo-instruct for completions) using the Azure AI Foundry portal.
- You explored the models in the **Completions and Chat playgrounds**, experimented with prompts and parameters, and tested the model’s **code generation abilities**.


### You have successfully completed the lab. Click on Next >> to proceed with the next exercise.
     
   ![](../media/next-1507.png)
