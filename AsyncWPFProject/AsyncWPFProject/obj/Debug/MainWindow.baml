   M S B A M L   `   `   `  ����J  FAsyncWPFProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:AsyncWPFProjectAsyncWPFProject  5   	        AsyncWPFProject.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:AsyncWPFProject     5   	     � Title$%  LIVE DIFFERENCES SYNC AND ASYNC��5   	   $��565.572��61   $	��800��6B   .��5	      � $��20q�6    � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $
��10 0q�6!   $��28(�6/   75Example to illustrate the differences(Sync and Async)5      �� 5   
   -   5         ��Name$ executeSync��5      $��1��6&   $��10q�63   $��10q�6?   .��6f   !Execute synchronously(UI locks)6�   �� 5   
   -   5        $ executeAsync��5      $��2��6'   $��10q�64   $��10q�6@   .��6h   Execute Asynchronously6�   �� 5   
   -   5        $ executeParallelAsync��5      $��3��6/   $��10q�6<   $��10q�6H   .��6x   Parallel Async6�   �� 5   
   -   5        $ cancelOperation��5      $��4��6*   $��10q�67   $��10q�6C   .��6n   CANCEL6v   � 5   
   -   5         �Name$ dashboardProgress��5       � Value$ 0Q�61   $��30��6;   $��10q�6G   $��5��6S   �� 5   
   -   5         ��Name$ resultsWindow��5      $��6��6+   $��10q�68   5      5      