using RulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using static RulesEngine.Extensions.ListofRuleResultTreeExtension;

namespace Rules
{
    public class RentechRules
    {

        public void Run()
        {
            List<Workflow> workflows = new List<Workflow>();
            Workflow workflowSuscription = new Workflow();
            Workflow workflowProduct = new Workflow();
            workflowSuscription.WorkflowName = "Suscription Rules";
            workflowProduct.WorkflowName = "Product Rules";

            /* SUSCRIPTION RULES */

            List<Rule> suscriptionRules = new List<Rule>();

            Rule rule1 = new Rule();
            Rule rule2 = new Rule();
            Rule rule3 = new Rule();
            Rule rule6 = new Rule();
            Rule rule8 = new Rule();
            Rule rule7 = new Rule();
            Rule rule9 = new Rule();
            Rule rule10 = new Rule();

            rule1.RuleName = "Test Rule";
            rule1.SuccessEvent = "Count is within tolerance.";
            rule1.ErrorMessage = "Over expected.";
            rule1.Expression = "count < 3";
            rule1.RuleExpressionType = RuleExpressionType.LambdaExpression;

            rule2.RuleName = "Test Rule";
            rule2.SuccessEvent = "Count is within tolerance.";
            rule2.ErrorMessage = "Over expected.";
            rule2.Expression = "count < 3";
            rule2.RuleExpressionType = RuleExpressionType.LambdaExpression;

            rule3.RuleName = "Test Rule";
            rule3.SuccessEvent = "Count is within tolerance.";
            rule3.ErrorMessage = "Over expected.";
            rule3.Expression = "count < 3";
            rule3.RuleExpressionType = RuleExpressionType.LambdaExpression;

            rule6.RuleName = "TwoWeekReturnTime";
            rule6.SuccessEvent = "True.";
            rule6.ErrorMessage = "You can't return the products right now.";
            rule6.Expression = "!suscription.isActive && suscription.endTime < 14";
            rule6.RuleExpressionType = RuleExpressionType.LambdaExpression;

            rule7.RuleName = "MaximumDataRecoveryTime";
            rule7.SuccessEvent = "True";
            rule7.ErrorMessage = "The data can't be recovered.";
            rule7.Expression = "!suscription.isActive && suscription.endTime < 14";
            rule7.RuleExpressionType = RuleExpressionType.LambdaExpression;

            rule8.RuleName = "Test Rule";
            rule8.SuccessEvent = "Count is within tolerance.";
            rule8.ErrorMessage = "Over expected.";
            rule8.Expression = "count < 3";
            rule8.RuleExpressionType = RuleExpressionType.LambdaExpression;

            rule9.RuleName = "TwoWeekRenewalReturnTime";
            rule9.SuccessEvent = "True.";
            rule9.ErrorMessage = "The products can't be returned.";
            rule9.Expression = "suscription.renewalTime < 14";
            rule9.RuleExpressionType = RuleExpressionType.LambdaExpression;

            rule10.RuleName = "Test Rule";
            rule10.SuccessEvent = "Count is within tolerance.";
            rule10.ErrorMessage = "Over expected.";
            rule10.Expression = "count < 3";
            rule10.RuleExpressionType = RuleExpressionType.LambdaExpression;

            suscriptionRules.Add(rule1);
            suscriptionRules.Add(rule2);
            suscriptionRules.Add(rule3);
            suscriptionRules.Add(rule6);
            suscriptionRules.Add(rule7);
            suscriptionRules.Add(rule9);
            suscriptionRules.Add(rule8);
            suscriptionRules.Add(rule10);

            workflowSuscription.Rules = suscriptionRules;

            /* PRODUCT RULES */

            List<Rule> productRules = new List<Rule>();

            Rule rule4 = new Rule();
            Rule rule5 = new Rule();

            rule4.RuleName = "MaximunServiceTime";
            rule4.SuccessEvent = "True.";
            rule4.ErrorMessage = "Maximum service time of product type is not defined.";
            rule4.Expression = "maximumServiceTime == maximumTypeServiceTime";
            rule4.RuleExpressionType = RuleExpressionType.LambdaExpression;

            rule5.RuleName = "MaximumServiceTimeExchange";
            rule5.SuccessEvent = "True.";
            rule5.ErrorMessage = "The product still has service time.";
            rule5.Expression = "timeInUse >= maximunServiceTime";
            rule5.RuleExpressionType = RuleExpressionType.LambdaExpression;

            //productRules.Add(rule4);
            productRules.Add(rule5);

            workflowProduct.Rules = productRules;

            workflows.Add(workflowSuscription);
            workflows.Add(workflowProduct);

            // ADD REST OF THE CODE IN THE GITHUB DEMO

            var bre = new RulesEngine.RulesEngine(workflows.ToArray(), null);

            dynamic datas = new ExpandoObject();
            /*datas.maximunServiceTime = 4;
            datas.maximumTypeServiceTime = 5;*/

            datas.timeInUse = 3;
            datas.maximumServiceTime = 5;
            var inputs = new dynamic[]
              {
                    datas
              };

            List<RuleResultTree> resultList = bre.ExecuteAllRulesAsync("Product Rules", inputs).Result;

            bool outcome = false;

            //Different ways to show test results:
            outcome = resultList.TrueForAll(r => r.IsSuccess);

            resultList.OnSuccess((eventName) =>
            {
                Console.WriteLine($"Result '{eventName}' is as expected.");
                outcome = true;
            });

            resultList.OnFail(() =>
            {
                outcome = false;
            });

            Console.WriteLine($"Test outcome: {outcome}.");

        }
    }

}