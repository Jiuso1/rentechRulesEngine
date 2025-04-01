using RulesEngine.Models;

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
Rule rule8 = new Rule();
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

rule8.RuleName = "Test Rule";
rule8.SuccessEvent = "Count is within tolerance.";
rule8.ErrorMessage = "Over expected.";
rule8.Expression = "count < 3";
rule8.RuleExpressionType = RuleExpressionType.LambdaExpression;

rule10.RuleName = "Test Rule";
rule10.SuccessEvent = "Count is within tolerance.";
rule10.ErrorMessage = "Over expected.";
rule10.Expression = "count < 3";
rule10.RuleExpressionType = RuleExpressionType.LambdaExpression;

suscriptionRules.Add(rule1);
suscriptionRules.Add(rule2);
suscriptionRules.Add(rule3);
suscriptionRules.Add(rule8);
suscriptionRules.Add(rule10);

workflowSuscription.Rules = suscriptionRules;

/* PRODUCT RULES */

List<Rule> productRules = new List<Rule>();

Rule rule4 = new Rule();
Rule rule5 = new Rule();
Rule rule6 = new Rule();
Rule rule7 = new Rule();
Rule rule9 = new Rule();

rule4.RuleName = "MaximunServiceTime";
rule4.SuccessEvent = "Count is within tolerance.";
rule4.ErrorMessage = "Over expected.";
rule4.Expression = "count < 3";
rule4.RuleExpressionType = RuleExpressionType.LambdaExpression;

rule5.RuleName = "MaximumServiceTimeExchange";
rule5.SuccessEvent = "Count is within tolerance.";
rule5.ErrorMessage = "Over expected.";
rule5.Expression = "count < 3";
rule5.RuleExpressionType = RuleExpressionType.LambdaExpression;

rule6.RuleName = "TwoWeekReturnTime";
rule6.SuccessEvent = "Count is within tolerance.";
rule6.ErrorMessage = "Over expected.";
rule6.Expression = "count < 3";
rule6.RuleExpressionType = RuleExpressionType.LambdaExpression;

rule7.RuleName = "MaximumDataRecoveryTime";
rule7.SuccessEvent = "Count is within tolerance.";
rule7.ErrorMessage = "Over expected.";
rule7.Expression = "count < 3";
rule7.RuleExpressionType = RuleExpressionType.LambdaExpression;

rule9.RuleName = "TwoWeekRenewalReturnTime";
rule9.SuccessEvent = "Count is within tolerance.";
rule9.ErrorMessage = "Over expected.";
rule9.Expression = "count < 3";
rule9.RuleExpressionType = RuleExpressionType.LambdaExpression;

productRules.Add(rule4);
productRules.Add(rule5);
productRules.Add(rule6);
productRules.Add(rule7);
productRules.Add(rule9);

workflowProduct.Rules = productRules;

workflows.Add(workflowSuscription);
workflows.Add(workflowProduct);

// ADD REST OF THE CODE IN THE GITHUB DEMO