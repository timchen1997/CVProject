   M S B A M L   `   `   `  ����D  @CVProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CVProject.DialogCVProject.Dialog  5   	   "    CVProject.Dialog.HoughDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CVProject.Dialog     5   	   X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Hough Transform��5	   	   $��161.364��6!   $	��300��62   ���	#FF363636 � WindowStyle$ 
ToolWindow=�6U    � WindowStartupLocation$ CenterScreen=�6n   .��5
      � .+�5   
   	� -   5         	�Name$ rbtnLine��5      $��Detect Line��6(   $
��Left=�6>   $��	10,10,0,0q�6Y   $	��Top=�6l   6�   	� 5   
   -   5        $ 
rbtnCircle��5      $��Detect Circle��6*   $
��Left=�6B   $��	10,60,0,0q�6]   $	��Top=�6p   6�   �� 5   
   -   5         ��Name$ label��5      $��	Threshold��6   $
��Left=�63   $��
140,10,0,0q�6N   $	��Top=�6b   %  Xceed.Wpf.Toolkit.IntegerUpDown  5   
   -   5        $��	threshold��5      $
��Left=�6.   $��	200,8,0,0q�6I   $	��Top=�6\   $��66��6t   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 50X�6      Minimum$ 0X�6�   �� 5   
   -   5        $ 
label_Copy��5      $��R Min��6$   $
��Left=�64   $��
140,35,0,0q�6O   $	��Top=�6c     5   
   -   5        $
��rmin��5      $
��Left=�6)   $��
200,33,0,0q�6D   $	��Top=�6X   $��66��6p   $	 100X�6{   $ 1X�6�   �� 5   
   -   5        $ label_Copy1��5      $��R Max��6%   $
��Left=�65   $��
140,60,0,0q�6P   $	��Top=�6d     5   
   -   5        $
��rmax��5      $
��Left=�6)   $��
200,58,0,0q�6D   $	��Top=�6X   $��66��6p   $	 200X�6{   $ 1X�6�   �� 5   
   -	   5         ��Name$ 	btnCancel��5      $��Cancel��6$   $
��Left=�65   $��
190,98,0,0q�6P   $	��Top=�6d   $��76��6|   6�   �� 5   
   -
   5        $ btnOK��5      $��OK��6    $
��Left=�6-   $��
109,98,0,0q�6H   $	��Top=�6\   $��76��6t   6   5      5      