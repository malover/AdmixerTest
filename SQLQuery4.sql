INSERT INTO DMZ (a.DDM, a.NDM, a.PR)
SELECT GETDATE() AS DOM,
       a.NDM AS NDM, 
       CASE WHEN a.PR_1_Count > a.PR_2_Count 
        THEN 2
        ELSE 1
       END AS PR
FROM (SELECT
        MAX(NDM) + 1 AS NDM,
        SUM(CASE WHEN PR = 1 THEN 1 ELSE 0 END) AS PR_1_Count, 
        SUM(CASE WHEN PR = 2 THEN 1 ELSE 0 END) AS PR_2_Count
       FROM DMZ) a